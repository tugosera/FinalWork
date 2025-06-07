using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            if ((await _database.GetItemsAsync()).Count == 0)
            {
                await _database.AddItemAsync(new DotaItem { Name = "Tango", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/items/tango.png", IsComposite = false, IsNeutral = false, InfoUrl = "https://www.dotabuff.com/items/tango" });
                await _database.AddItemAsync(new DotaItem { Name = "Phase Boots", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/items/phase_boots.png", IsComposite = true, IsNeutral = false, InfoUrl = "https://www.dotabuff.com/items/phase-boots" });
                await _database.AddItemAsync(new DotaItem { Name = "Arcane Ring", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/items/arcane_ring.png", IsComposite = false, IsNeutral = true, InfoUrl = "https://www.dotabuff.com/items/arcane-ring" });
            }

            _allItems = await _database.GetItemsAsync();
            GenerateItemButtons(_allItems);
        }

        private void GenerateItemButtons(IEnumerable<DotaItem> items)
        {
            ItemGrid.Children.Clear();
            ItemGrid.RowDefinitions.Clear();
            ItemGrid.ColumnDefinitions.Clear();

            int columns = 3;
            for (int i = 0; i < columns; i++)
                ItemGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            var itemList = items.ToList();
            for (int i = 0; i < itemList.Count; i++)
            {
                var item = itemList[i];
                var button = new ImageButton
                {
                    Source = item.IconUrl,
                    WidthRequest = 100,
                    HeightRequest = 100,
                    BorderColor = Colors.Black,
                    BorderWidth = 1,
                    CornerRadius = 0,
                    BackgroundColor = Colors.Transparent,
                    Aspect = Aspect.AspectFill,
                };

                button.Clicked += (s, e) => OnItemSelected(item);

                int row = i / columns;
                int column = i % columns;

                while (ItemGrid.RowDefinitions.Count <= row)
                    ItemGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
                ItemGrid.Children.Add(button);
            }
        }

        private async void OnItemSelected(DotaItem item)
        {
            await Navigation.PushAsync(new ItemDetailPage(item));
        }

        private void OnNormalClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            var filtered = _allItems.Where(i => !i.IsComposite && !i.IsNeutral);
            GenerateItemButtons(filtered);
        }

        private void OnCompositeClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            var filtered = _allItems.Where(i => i.IsComposite && !i.IsNeutral);
            GenerateItemButtons(filtered);
        }

        private void OnNeutralClicked(object sender, EventArgs e)
        {
            if (_allItems == null) return;
            var filtered = _allItems.Where(i => i.IsNeutral);
            GenerateItemButtons(filtered);
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
    }
}