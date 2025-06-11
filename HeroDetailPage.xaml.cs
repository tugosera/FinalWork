using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SQLite;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinalWork
{
    public partial class HeroDetailPage : ContentPage
    {
        private DotaHero _hero;
        private SQLiteAsyncConnection _db;
        private string _username;
        private bool _isFavorite = false;

        public HeroDetailPage(DotaHero hero)
        {
            InitializeComponent();
            _hero = hero;

            // Назначаем иконку героя
            HeroIcon.Source = _hero.IconUrl;
            HeroName.Text = _hero.Name;

            LoadHeroPage(_hero.InfoUrl);

            InitDatabase();
        }

        private async void InitDatabase()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "favorites.db");
            _db = new SQLiteAsyncConnection(dbPath);
            await _db.CreateTableAsync<FavoriteHero>();

            _username = Preferences.Get("LoggedInUsername", null);

            if (!string.IsNullOrEmpty(_username))
            {
                var existing = await _db.Table<FavoriteHero>()
                    .FirstOrDefaultAsync(f => f.Username == _username && f.HeroName == _hero.Name);

                if (existing != null)
                {
                    _isFavorite = true;
                    FavoriteButton.Source = "star_filled.png";
                }
            }
        }

        private async void OnFavoriteClicked(object sender, EventArgs e)
        {
            _username = Preferences.Get("LoggedInUsername", null);
            if (string.IsNullOrEmpty(_username))
            {
                await DisplayAlert("Ошибка", "Надо авторизироваться", "OK");
                return;
            }

            _isFavorite = !_isFavorite;
            FavoriteButton.Source = _isFavorite ? "star_filled.png" : "star_outline.png";

            if (_isFavorite)
            {
                await _db.InsertAsync(new FavoriteHero
                {
                    Username = _username,
                    HeroName = _hero.Name
                });
            }
            else
            {
                var existing = await _db.Table<FavoriteHero>()
                    .FirstOrDefaultAsync(f => f.Username == _username && f.HeroName == _hero.Name);
                if (existing != null)
                {
                    await _db.DeleteAsync(existing);
                }
            }
        }

        private async void LoadHeroPage(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var html = await response.Content.ReadAsStringAsync();

                    if (html.Contains("dota_react_hero") || html.Contains("hero_picker__hero-name") || html.Contains("dota2.com"))
                    {
                        HeroWebView.Source = url;
                    }
                    else
                    {
                        HeroWebView.Source = new HtmlWebViewSource
                        {
                            Html = $"<html><body><h2>Информация о герое <b>{_hero.Name}</b> недоступна.</h2></body></html>"
                        };
                    }
                }
                else
                {
                    HeroWebView.Source = new HtmlWebViewSource
                    {
                        Html = $"<html><body><h2>Страница для героя <b>{_hero.Name}</b> не найдена.</h2></body></html>"
                    };
                }
            }
            catch
            {
                HeroWebView.Source = new HtmlWebViewSource
                {
                    Html = $"<html><body><h2>Ошибка загрузки страницы для героя <b>{_hero.Name}</b>.</h2></body></html>"
                };
            }
        }

        public class FavoriteHero
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Username { get; set; }
            public string HeroName { get; set; }
        }
    }
}
