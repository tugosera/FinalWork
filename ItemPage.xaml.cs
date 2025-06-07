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
    public partial class ItemPage : ContentPage
    {
        private DotaItemDatabase _database;
        private List<DotaItem> _allItems;

        public ItemPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "items.db");
            _database = new DotaItemDatabase(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Очистка базы перед загрузкой новых данных
            await _database.ClearItemsAsync();

            var items = await FetchDotaItemsAsync();

            foreach (var item in items)
                await _database.AddItemAsync(item);

            _allItems = await _database.GetItemsAsync();
            ShowItems(_allItems);
        }

        private void ShowItems(IEnumerable<DotaItem> items)
        {
            ItemCollectionView.ItemsSource = items;
        }

        private async Task<List<DotaItem>> FetchDotaItemsAsync()
        {
            var items = new List<DotaItem>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://api.opendota.com/api/constants/items");
            var jsonDoc = JsonDocument.Parse(response);

            foreach (var itemElement in jsonDoc.RootElement.EnumerateObject())
            {
                var key = itemElement.Name;
                var data = itemElement.Value;

                if (!data.TryGetProperty("dname", out var nameProp)) continue;
                var name = nameProp.GetString();

                var shortKey = key.Replace("item_", "");

                // Если ключ начинается с recipe — используем общую иконку рецепта
                string iconUrl;
                if (shortKey.StartsWith("recipe"))
                {
                    iconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/items/recipe.png";
                }
                else
                {
                    iconUrl = $"https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/items/{shortKey}.png";
                }

                var isComposite = data.TryGetProperty("components", out var components) && components.ValueKind == JsonValueKind.Array && components.GetArrayLength() > 0;
                var isNeutral = data.TryGetProperty("neutral_item", out var neutralProp) && neutralProp.GetBoolean();
                var infoUrl = $"https://www.dotabuff.com/items/{shortKey.Replace("_", "-")}";

                items.Add(new DotaItem
                {
                    Name = name,
                    IconUrl = iconUrl,
                    IsComposite = isComposite,
                    IsNeutral = isNeutral,
                    InfoUrl = infoUrl
                });
            }

            return items;
        }

        private void OnNormalClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            var filtered = _allItems.Where(i => !i.IsComposite && !i.IsNeutral);
            ShowItems(filtered);
        }

        private void OnCompositeClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            var filtered = _allItems.Where(i => i.IsComposite && !i.IsNeutral);
            ShowItems(filtered);
        }

        private void OnNeutralClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            var filtered = _allItems.Where(i => i.IsNeutral);
            ShowItems(filtered);
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is DotaItem selectedItem)
            {
                await Navigation.PushAsync(new ItemDetailPage(selectedItem));
                // Сброс выделения
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }

    public class DotaItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string InfoUrl { get; set; }
        public bool IsComposite { get; set; }
        public bool IsNeutral { get; set; }
    }

    public class DotaItemDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public DotaItemDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<DotaItem>().Wait();
        }

        public Task<List<DotaItem>> GetItemsAsync() => _db.Table<DotaItem>().ToListAsync();
        public Task<int> AddItemAsync(DotaItem item) => _db.InsertAsync(item);
        public Task<int> ClearItemsAsync() => _db.DeleteAllAsync<DotaItem>();
    }
}
