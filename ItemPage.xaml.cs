using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
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

            // 1. Сначала загрузка из локальной базы (кэш)
            _allItems = await _database.GetItemsAsync();
            if (_allItems.Any())
            {
                ShowItems(_allItems);
            }

            // 2. Фоновое обновление из API
            _ = Task.Run(async () => await UpdateItemsFromApiAsync());
        }

        private async Task UpdateItemsFromApiAsync()
        {
            try
            {
                var itemsFromApi = await FetchDotaItemsAsync();

                if (itemsFromApi?.Count > 0)
                {
                    await _database.ClearItemsAsync();

                    foreach (var item in itemsFromApi)
                    {
                        await _database.AddItemAsync(item);
                    }

                    _allItems = itemsFromApi;

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        ShowItems(_allItems);
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении предметов: {ex.Message}");
            }
        }

        private void ShowItems(IEnumerable<DotaItem> items)
        {
            ItemCollectionView.ItemsSource = items;
        }

        private async Task<List<DotaItem>> FetchDotaItemsAsync()
        {
            var items = new List<DotaItem>();
            using var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://api.opendota.com/api/constants/items");
            using var jsonDoc = JsonDocument.Parse(response);

            foreach (var itemElement in jsonDoc.RootElement.EnumerateObject())
            {
                var key = itemElement.Name;
                var data = itemElement.Value;

                if (!data.TryGetProperty("dname", out var nameProp)) continue;
                var name = nameProp.GetString();

                var shortKey = key.Replace("item_", "");

                // Исключаем предметы, в названии которых есть "recipe"
                if (shortKey.Contains("recipe", StringComparison.OrdinalIgnoreCase))
                    continue;

                string iconUrl = $"https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/items/{shortKey}.png";

                int componentsCount = 0;
                if (data.TryGetProperty("components", out var components) && components.ValueKind == JsonValueKind.Array)
                {
                    componentsCount = components.GetArrayLength();
                }

                bool isComposite = componentsCount > 0;

                bool isNeutral = false;
                if (data.TryGetProperty("neutral_item", out var neutralProp))
                {
                    isNeutral = neutralProp.ValueKind switch
                    {
                        JsonValueKind.True => true,
                        JsonValueKind.Number => neutralProp.GetInt32() == 1,
                        _ => false
                    };
                }
                else if (data.TryGetProperty("item_neutral", out var itemNeutralProp))
                {
                    isNeutral = itemNeutralProp.ValueKind switch
                    {
                        JsonValueKind.True => true,
                        JsonValueKind.Number => itemNeutralProp.GetInt32() == 1,
                        _ => false
                    };
                }

                var infoUrl = $"https://www.dotabuff.com/items/{shortKey.Replace("_", "-")}";

                items.Add(new DotaItem
                {
                    Name = name,
                    IconUrl = iconUrl,
                    IsComposite = isComposite,
                    ComponentsCount = componentsCount,
                    IsNeutral = isNeutral,
                    InfoUrl = infoUrl
                });
            }

            return items;
        }

        private void OnNormalClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            // Показываем только обычные предметы, которые не являются рецептом и не собираются из других
            var filtered = _allItems.Where(i => !i.IsComposite && !i.IsNeutral);
            ShowItems(filtered);
        }

        private void OnCompositeClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            var filtered = _allItems.Where(i => i.IsComposite && !i.IsNeutral);
            ShowItems(filtered);
        }

        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is DotaItem selectedItem)
            {
                await Navigation.PushAsync(new ItemDetailPage(selectedItem));
                ((CollectionView)sender).SelectedItem = null; // сброс выделения
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
        public int ComponentsCount { get; set; }  // Можно добавить, если нужно
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
