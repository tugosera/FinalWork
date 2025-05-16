using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using SQLite;

namespace FinalWork
{
    public partial class Heroes : ContentPage
    {
        private DotaDatabase _database;

        public Heroes()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "dota.db");
            _database = new DotaDatabase(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Добавляем героев в БД при первом запуске
            if ((await _database.GetHeroesAsync()).Count == 0)
            {
await _database.AddHeroAsync(new DotaHero { Name = "Antimage", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/antimage.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Axe", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/axe.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Bane", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bane.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Bloodseeker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bloodseeker.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Crystal Maiden", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/crystal_maiden.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Drow Ranger", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/drow_ranger.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Earthshaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/earthshaker.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Juggernaut", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/juggernaut.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Mirana", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/mirana.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Morphling", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/morphling.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Nevermore", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/nevermore.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Phantom Lancer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phantom_lancer.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Puck", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/puck.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Pudge", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pudge.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Razor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/razor.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Sand King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sand_king.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Storm Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/storm_spirit.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Sven", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sven.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Tiny", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tiny.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Vengefulspirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/vengefulspirit.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Windrunner", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/windrunner.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Zeus", IconUrl = "https://static.wikia.nocookie.net/dota2_gamepedia/images/3/3f/Zeus_icon.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Kunkka", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/kunkka.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Lina", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lina.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Lich", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lich.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Lion", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lion.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Shadow Shaman", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shadow_shaman.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Slardar", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/slardar.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Tidehunter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tidehunter.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Witch Doctor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/witch_doctor.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Riki", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/riki.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Enigma", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/enigma.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Tinker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tinker.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Sniper", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sniper.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Necrolyte", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/necrolyte.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Warlock", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/warlock.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Beastmaster", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/beastmaster.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Queenofpain", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/queenofpain.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Venomancer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/venomancer.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Faceless Void", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/faceless_void.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Skeleton King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/skeleton_king.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Death Prophet", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/death_prophet.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Phantom Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phantom_assassin.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Pugna", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pugna.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Templar Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/templar_assassin.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Viper", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/viper.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Luna", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/luna.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Dragon Knight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dragon_knight.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Dazzle", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dazzle.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Clockwerk", IconUrl = "https://static.wikia.nocookie.net/dota2_gamepedia/images/d/d8/Clockwerk_icon.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Leshrac", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/leshrac.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Furion", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/furion.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Life Stealer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/life_stealer.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Dark Seer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dark_seer.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Clinkz", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/clinkz.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Omniknight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/omniknight.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Enchantress", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/enchantress.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Huskar", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/huskar.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Night Stalker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/night_stalker.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Broodmother", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/broodmother.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Bounty Hunter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bounty_hunter.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Weaver", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/weaver.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Jakiro", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/jakiro.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Batrider", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/batrider.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Chen", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/chen.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Spectre", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/spectre.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Doom Bringer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/doom_bringer.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Ancient Apparition", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ancient_apparition.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Ursa", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ursa.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Spirit Breaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/spirit_breaker.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Gyrocopter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/gyrocopter.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Alchemist", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/alchemist.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Invoker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/invoker.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Silencer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/silencer.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Obsidian Destroyer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/obsidian_destroyer.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Lycan", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lycan.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Brewmaster", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/brewmaster.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Shadow Demon", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shadow_demon.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Lone Druid", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lone_druid.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Chaos Knight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/chaos_knight.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Meepo", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/meepo.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Treant", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/treant.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Ogre Magi", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ogre_magi.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Undying", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/undying.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Rubick", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/rubick.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Disruptor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/disruptor.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Nyx Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/nyx_assassin.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Naga Siren", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/naga_siren.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Keeper of The Light", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/keeper_of_the_light.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Wisp", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/wisp.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Slark", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/slark.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Medusa", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/medusa.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Troll Warlord", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/troll_warlord.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Centaur", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/centaur.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Magnataur", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/magnataur.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Shredder", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shredder.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Bristleback", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bristleback.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Tusk", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tusk.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Skywrath Mage", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/skywrath_mage.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Abaddon", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/abaddon.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Elder Titan", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/elder_titan.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Legion Commander", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/legion_commander.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Techies", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/techies.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Ember Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ember_spirit.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Earth Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/earth_spirit.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Terrorblade", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/terrorblade.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Phoenix", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phoenix.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Oracle", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/oracle.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Winter Wyvern", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/winter_wyvern.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Arc Warden", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/arc_warden.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Monkey King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/monkey_king.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Dark Willow", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dark_willow.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Pangolier", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pangolier.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Grimstroke", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/grimstroke.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Hoodwink", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/hoodwink.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Void Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/void_spirit.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Snapfire", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/snapfire.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Mars", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/mars.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Dawnbreaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dawnbreaker.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Marci", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/marci.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Primal Beast", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/primal_beast.png" });
await _database.AddHeroAsync(new DotaHero { Name = "Muerta", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/muerta.png" });            }

            var heroes = await _database.GetHeroesAsync();
            GenerateHeroButtons(heroes);
        }

        private void GenerateHeroButtons(List<DotaHero> heroes)
        {
            HeroesGrid.Children.Clear();
            HeroesGrid.RowDefinitions.Clear();
            HeroesGrid.ColumnDefinitions.Clear();
             
            int columns = 3;
            for (int i = 0; i < columns; i++)
                HeroesGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            for (int i = 0; i < heroes.Count; i++)
            {
                var hero = heroes[i];
                var button = new ImageButton
                {
                    Source = hero.IconUrl,
                    WidthRequest = 100,
                    HeightRequest = 100,
                    BackgroundColor = Colors.Transparent,
                    Aspect = Aspect.AspectFill
                };

                button.Clicked += (s, e) =>
                {
                    DisplayAlert("Герой", hero.Name, "OK");
                };

                int row = i / columns;
                int column = i % columns;

                // Добавляем новую строку при необходимости
                while (HeroesGrid.RowDefinitions.Count <= row)
                    HeroesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
                HeroesGrid.Children.Add(button);
            }
        }
    }

    public class DotaHero
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
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
    }
}