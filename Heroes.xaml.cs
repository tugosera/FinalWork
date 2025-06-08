using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using SQLite;

namespace FinalWork
{
    public partial class Heroes : ContentPage
    {
        private DotaDatabase _database;
        private List<DotaHero> _allHeroes;

        public Heroes()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "dota.db");
            _database = new DotaDatabase(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadHeroesAsync();
        }

        private async Task LoadHeroesAsync()
        {
            await _database.ClearHeroesAsync();

            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://api.opendota.com/api/heroStats");
            var heroesFromApi = JsonSerializer.Deserialize<List<HeroApiModel>>(response);

            foreach (var hero in heroesFromApi)
            {
                var shortName = hero.name.Replace("npc_dota_hero_", "");
                var urlName = shortName.Replace("_", "").Replace("-", "").ToLower();

                string attribute = hero.primary_attr switch
                {
                    "str" => "Strength",
                    "agi" => "Agility",
                    "int" => "Intelligence",
                    "all" => "Universal",
                    _ => "Universal"
                };

                var heroData = new DotaHero
                {
                    Name = hero.localized_name,
                    IconUrl = $"https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/{shortName}.png",
                    InfoUrl = $"https://www.dota2.com/hero/{urlName}",
                    MainAttribute = attribute
                };

                await _database.AddHeroAsync(heroData);
            }

            _allHeroes = await _database.GetHeroesAsync();
            GenerateHeroButtons(_allHeroes);
        }

        private void GenerateHeroButtons(IEnumerable<DotaHero> heroes)
        {
            HeroesGrid.Children.Clear();
            HeroesGrid.RowDefinitions.Clear();

            int columns = 3;
            var heroList = heroes.ToList();

            for (int i = 0; i < heroList.Count; i++)
            {
                var hero = heroList[i];

                var button = new ImageButton
                {
                    Source = hero.IconUrl,
                    WidthRequest = 100,
                    HeightRequest = 100,
                    BackgroundColor = Colors.Transparent,
                    BorderWidth = 1
                };
                button.Clicked += (s, e) => OnHeroSelected(hero);

                int row = i / columns;
                int column = i % columns;

                while (HeroesGrid.RowDefinitions.Count <= row)
                    HeroesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
                HeroesGrid.Children.Add(button);
            }
        }

        private void OnStrengthClicked(object sender, EventArgs e) => FilterByAttribute("Strength");
        private void OnAgilityClicked(object sender, EventArgs e) => FilterByAttribute("Agility");
        private void OnIntelligenceClicked(object sender, EventArgs e) => FilterByAttribute("Intelligence");
        private void OnUniversalClicked(object sender, EventArgs e) => FilterByAttribute("Universal");

        private void FilterByAttribute(string attr)
        {
            if (_allHeroes == null) return;
            var filtered = _allHeroes.Where(h => h.MainAttribute == attr);
            GenerateHeroButtons(filtered);
        }

        private async void OnHeroSelected(DotaHero hero)
        {
            await Navigation.PushAsync(new HeroDetailPage(hero));
        }

        private class HeroApiModel
        {
            public string name { get; set; }
            public string localized_name { get; set; }
            public string primary_attr { get; set; }
        }
    }

    public class DotaHero
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string MainAttribute { get; set; }
        public string InfoUrl { get; set; }
    }

    public class DotaDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public DotaDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<DotaHero>().Wait();
        }

        public Task<List<DotaHero>> GetHeroesAsync() => _db.Table<DotaHero>().ToListAsync();
        public Task<int> AddHeroAsync(DotaHero hero) => _db.InsertAsync(hero);
        public Task<int> ClearHeroesAsync() => _db.DeleteAllAsync<DotaHero>();
    }
}
