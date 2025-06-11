using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FinalWork
{
    public partial class ItemDetailPage : ContentPage
    {
        private DotaItem _item;
        private SQLiteAsyncConnection _db;
        private bool _isFavorite = false;

        public ItemDetailPage(DotaItem item)
        {
            InitializeComponent();

            _item = item;

            // Инициализация базы данных для избранного
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<FavoriteItem>().Wait();

            ItemIcon.Source = _item.IconUrl;
            ItemName.Text = _item.Name;

            if (!string.IsNullOrWhiteSpace(_item.InfoUrl))
            {
                var url = _item.InfoUrl.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = "https://" + url;

                ItemWebView.Source = url;
            }
            else
            {
                ItemWebView.Source = new HtmlWebViewSource
                {
                    Html = "<html><body><h3>Информация отсутствует</h3></body></html>"
                };
            }

            CheckIfFavoriteAsync();
        }

        // Проверяем, есть ли предмет в избранном пользователя, чтобы сразу выставить звезду
        private async void CheckIfFavoriteAsync()
        {
            if (!Preferences.Get("IsLoggedIn", false))
            {
                SetStar(false);
                return;
            }

            string username = Preferences.Get("LoggedInUsername", "");
            if (string.IsNullOrEmpty(username))
            {
                SetStar(false);
                return;
            }

            var fav = await _db.Table<FavoriteItem>().FirstOrDefaultAsync(f => f.Username == username && f.ItemName == _item.Name);
            SetStar(fav != null);
        }

        private void SetStar(bool filled)
        {
            _isFavorite = filled;
            FavoriteStar.Source = filled ? "star_filled.png" : "star_outline.png";
        }

        private async void OnFavoriteStarTapped(object sender, EventArgs e)
        {
            bool isLoggedIn = Preferences.Get("IsLoggedIn", false);
            if (!isLoggedIn)
            {
                await DisplayAlert("Ошибка", "надо авторизироваться", "OK");
                return;
            }

            string username = Preferences.Get("LoggedInUsername", "");
            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Ошибка", "надо авторизироваться", "OK");
                return;
            }

            if (_isFavorite)
            {
                // Удаляем из избранного
                var fav = await _db.Table<FavoriteItem>().FirstOrDefaultAsync(f => f.Username == username && f.ItemName == _item.Name);
                if (fav != null)
                {
                    await _db.DeleteAsync(fav);
                }
                SetStar(false);
            }
            else
            {
                // Добавляем в избранное
                var fav = new FavoriteItem
                {
                    Username = username,
                    ItemName = _item.Name,
                    IconUrl = _item.IconUrl,
                    InfoUrl = _item.InfoUrl
                };
                await _db.InsertAsync(fav);
                SetStar(true);
            }
        }

        // Класс для таблицы избранных предметов, привязанный к конкретному пользователю
        public class FavoriteItem
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            public string Username { get; set; }

            public string ItemName { get; set; }

            public string IconUrl { get; set; }

            public string InfoUrl { get; set; }
        }
    }
}
