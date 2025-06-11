using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SQLite;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWork
{
    public partial class FavoriteItemsPage : ContentPage
    {
        private SQLiteAsyncConnection _db;
        private ObservableCollection<DotaItem> _favoriteItems = new ObservableCollection<DotaItem>();

        public FavoriteItemsPage()
        {
            InitializeComponent();

            BindingContext = this;

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<ItemDetailPage.FavoriteItem>().Wait();

            FavoriteItemsCollectionView.ItemsSource = _favoriteItems;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadFavoriteItemsAsync();
        }

        private async Task LoadFavoriteItemsAsync()
        {
            _favoriteItems.Clear();

            if (!Preferences.Get("IsLoggedIn", false))
            {
                await DisplayAlert("Ошибка", "Вы не авторизованы", "OK");
                return;
            }

            string username = Preferences.Get("LoggedInUsername", "");
            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Ошибка", "Вы не авторизованы", "OK");
                return;
            }

            var favs = await _db.Table<ItemDetailPage.FavoriteItem>()
                               .Where(f => f.Username == username)
                               .ToListAsync();

            foreach (var fav in favs)
            {
                _favoriteItems.Add(new DotaItem
                {
                    Name = fav.ItemName,
                    IconUrl = fav.IconUrl,
                    InfoUrl = fav.InfoUrl
                });
            }
        }

        private async void OnItemSelected(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is DotaItem selectedItem)
            {
                await Navigation.PushAsync(new ItemDetailPage(selectedItem));
            }
        }
    }
}
