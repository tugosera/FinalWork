using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using Android.Hardware.Camera2.Params;
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
            _allHeroes = await _database.GetHeroesAsync();

            if ((await _database.GetHeroesAsync()).Count == 0)
            {
                await _database.AddHeroAsync(new DotaHero { Name = "Antimage", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/antimage.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Axe", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/axe.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bane", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bane.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bloodseeker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bloodseeker.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Crystal Maiden", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/crystal_maiden.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Drow Ranger", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/drow_ranger.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Earthshaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/earthshaker.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Juggernaut", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/juggernaut.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Mirana", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/mirana.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Morphling", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/morphling.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Nevermore", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/nevermore.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Phantom Lancer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phantom_lancer.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Puck", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/puck.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Pudge", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pudge.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Razor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/razor.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Sand King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sand_king.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Storm Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/storm_spirit.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Sven", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sven.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tiny", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tiny.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Vengefulspirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/vengefulspirit.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Windrunner", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/windrunner.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Zeus", IconUrl = "https://static.wikia.nocookie.net/dota2_gamepedia/images/3/3f/Zeus_icon.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Kunkka", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/kunkka.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lina", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lina.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lich", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lich.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lion", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lion.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Shadow Shaman", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shadow_shaman.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Slardar", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/slardar.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tidehunter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tidehunter.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Witch Doctor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/witch_doctor.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Riki", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/riki.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Enigma", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/enigma.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tinker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tinker.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Sniper", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sniper.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Necrolyte", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/necrolyte.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Warlock", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/warlock.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Beastmaster", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/beastmaster.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Queenofpain", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/queenofpain.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Venomancer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/venomancer.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Faceless Void", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/faceless_void.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Skeleton King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/skeleton_king.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Death Prophet", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/death_prophet.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Phantom Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phantom_assassin.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Pugna", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pugna.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Templar Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/templar_assassin.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Viper", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/viper.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Luna", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/luna.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dragon Knight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dragon_knight.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dazzle", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dazzle.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Clockwerk", IconUrl = "https://static.wikia.nocookie.net/dota2_gamepedia/images/d/d8/Clockwerk_icon.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Leshrac", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/leshrac.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Furion", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/furion.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Life Stealer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/life_stealer.png", MainAttribute = "Strenght" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dark Seer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dark_seer.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Clinkz", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/clinkz.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Omniknight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/omniknight.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Enchantress", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/enchantress.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Huskar", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/huskar.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Night Stalker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/night_stalker.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Broodmother", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/broodmother.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bounty Hunter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bounty_hunter.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Weaver", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/weaver.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Jakiro", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/jakiro.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Batrider", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/batrider.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Chen", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/chen.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Spectre", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/spectre.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Doom Bringer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/doom_bringer.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ancient Apparition", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ancient_apparition.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ursa", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ursa.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Spirit Breaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/spirit_breaker.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Gyrocopter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/gyrocopter.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Alchemist", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/alchemist.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Invoker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/invoker.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Silencer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/silencer.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Obsidian Destroyer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/obsidian_destroyer.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lycan", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lycan.png", MainAttribute = "Strenght" });
                await _database.AddHeroAsync(new DotaHero { Name = "Brewmaster", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/brewmaster.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Shadow Demon", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shadow_demon.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lone Druid", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lone_druid.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Chaos Knight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/chaos_knight.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Meepo", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/meepo.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Treant", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/treant.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ogre Magi", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ogre_magi.png", MainAttribute = "Strenght" });
                await _database.AddHeroAsync(new DotaHero { Name = "Undying", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/undying.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Rubick", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/rubick.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Disruptor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/disruptor.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Nyx Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/nyx_assassin.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Naga Siren", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/naga_siren.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Keeper of The Light", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/keeper_of_the_light.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Wisp", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/wisp.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Slark", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/slark.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Medusa", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/medusa.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Troll Warlord", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/troll_warlord.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Centaur", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/centaur.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Magnus", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/magnataur.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Timbersaw", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shredder.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bristleback", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bristleback.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tusk", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tusk.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Skywrath Mage", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/skywrath_mage.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Abaddon", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/abaddon.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Elder Titan", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/elder_titan.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Legion Commander", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/legion_commander.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Techies", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/techies.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ember Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ember_spirit.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Earth Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/earth_spirit.png", MainAttribute = "Strenght" });
                await _database.AddHeroAsync(new DotaHero { Name = "Terrorblade", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/terrorblade.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Phoenix", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phoenix.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Oracle", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/oracle.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Winter Wyvern", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/winter_wyvern.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Arc Warden", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/arc_warden.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Monkey King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/monkey_king.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dark Willow", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dark_willow.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Pangolier", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pangolier.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Grimstroke", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/grimstroke.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Hoodwink", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/hoodwink.png", MainAttribute = "Agility" });
                await _database.AddHeroAsync(new DotaHero { Name = "Void Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/void_spirit.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Snapfire", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/snapfire.png", MainAttribute = "Intelligence" });
                await _database.AddHeroAsync(new DotaHero { Name = "Mars", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/mars.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dawnbreaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dawnbreaker.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Marci", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/marci.png", MainAttribute = "Universal" });
                await _database.AddHeroAsync(new DotaHero { Name = "Primal Beast", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/primal_beast.png", MainAttribute = "Strength" });
                await _database.AddHeroAsync(new DotaHero { Name = "Muerta", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/muerta.png", MainAttribute = "Intelligence" });
            }

            var heroes = await _database.GetHeroesAsync();
            GenerateHeroButtons(heroes);
        }

        private void GenerateHeroButtons(IEnumerable<DotaHero> heroes)
        {
            HeroesGrid.Children.Clear();
            HeroesGrid.RowDefinitions.Clear();
            HeroesGrid.ColumnDefinitions.Clear();

            int columns = 3;
            for (int i = 0; i < columns; i++)
                HeroesGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
             
            var heroList = heroes.ToList();
            for (int i = 0; i < heroList.Count; i++)
            {
                var hero = heroList[i];
                var button = new ImageButton
                {
                    Source = hero.IconUrl,
                    WidthRequest = 100,
                    HeightRequest = 100,
                    BorderColor = Colors.Black,
                    BorderWidth = 1,
                    CornerRadius = 0,
                    BackgroundColor = Colors.Transparent,
                    Aspect = Aspect.AspectFill
                };

                button.Clicked += (s, e) =>
                {
                    DisplayAlert("Герой", hero.Name, "OK");
                };

                int row = i / columns;
                int column = i % columns;

                while (HeroesGrid.RowDefinitions.Count <= row)
                    HeroesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
                HeroesGrid.Children.Add(button);
            }
        }

        private void OnStrengthClicked(object sender, EventArgs e)
        {
            if (_allHeroes == null) return;
            var filtered = _allHeroes.Where(h => h.MainAttribute == "Strength");
            GenerateHeroButtons(filtered);
        }

        private void OnAgilityClicked(object sender, EventArgs e)
        {
            if (_allHeroes == null) return;
            var filtered = _allHeroes.Where(h => h.MainAttribute == "Agility");
            GenerateHeroButtons(filtered);
        }

        private void OnIntelligenceClicked(object sender, EventArgs e)
        {
            if (_allHeroes == null) return;
            var filtered = _allHeroes.Where(h => h.MainAttribute == "Intelligence");
            GenerateHeroButtons(filtered);
        }

        private void OnUniversalClicked(object sender, EventArgs e)
        {
            if (_allHeroes == null) return;
            var filtered = _allHeroes.Where(h => h.MainAttribute == "Universal");
            GenerateHeroButtons(filtered);
        }
    }

    public class DotaHero
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string IconUrl { get; set; }

        public string MainAttribute { get; set; }
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