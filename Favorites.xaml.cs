using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWork
{
    public partial class Favorites : ContentPage
    {
        private SQLiteAsyncConnection _db;
        private string _username;
        private DotaDatabase _dotaDatabase; // Для получения полного объекта героя
        private List<DotaHero> _allHeroes;   // Все герои из базы

        public Favorites()
        {
            InitializeComponent();

            // Инициализируем соединение с БД избранного
            string favDbPath = Path.Combine(FileSystem.AppDataDirectory, "favorites.db");
            _db = new SQLiteAsyncConnection(favDbPath);

            // Инициализируем основную базу с героями
            string dotaDbPath = Path.Combine(FileSystem.AppDataDirectory, "dota.db");
            _dotaDatabase = new DotaDatabase(dotaDbPath);

            _username = Preferences.Get("LoggedInUsername", null);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (string.IsNullOrEmpty(_username))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, авторизуйтесь, чтобы просматривать избранных героев.", "OK");
                await Navigation.PopAsync();
                return;
            }

            await LoadFavoritesAsync();
        }

        private async Task LoadFavoritesAsync()
        {
            await _db.CreateTableAsync<HeroDetailPage.FavoriteHero>();
            var favoriteEntries = await _db.Table<HeroDetailPage.FavoriteHero>()
                .Where(f => f.Username == _username)
                .ToListAsync();

            _allHeroes = await _dotaDatabase.GetHeroesAsync();

            var favoriteHeroes = new List<DotaHero>();

            foreach (var fav in favoriteEntries)
            {
                var hero = _allHeroes.FirstOrDefault(h => h.Name == fav.HeroName);
                if (hero != null)
                    favoriteHeroes.Add(hero);
            }

            GenerateHeroButtons(favoriteHeroes);
        }

        private void GenerateHeroButtons(IEnumerable<DotaHero> heroes)
        {
            FavoritesGrid.Children.Clear();
            FavoritesGrid.RowDefinitions.Clear();

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

                while (FavoritesGrid.RowDefinitions.Count <= row)
                    FavoritesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
                FavoritesGrid.Children.Add(button);
            }
        }

        private async void OnHeroSelected(DotaHero hero)
        {
            await Navigation.PushAsync(new HeroDetailPage(hero));
        }
    }
}
