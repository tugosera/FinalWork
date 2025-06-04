using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            // Очистка базы данных при первом запуске (можно удалить позже)
            await _database.ClearHeroesAsync();

            if ((await _database.GetHeroesAsync()).Count == 0)
            {
                await _database.AddHeroAsync(new DotaHero { Name = "Antimage", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/antimage.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/anti-mage" });
                await _database.AddHeroAsync(new DotaHero { Name = "Axe", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/axe.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/axe" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bane", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bane.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/bane" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bloodseeker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bloodseeker.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/bloodseeker" });
                await _database.AddHeroAsync(new DotaHero { Name = "Crystal Maiden", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/crystal_maiden.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/crystalmaiden" });
                await _database.AddHeroAsync(new DotaHero { Name = "Drow Ranger", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/drow_ranger.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/drowranger" });
                await _database.AddHeroAsync(new DotaHero { Name = "Earthshaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/earthshaker.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/earthshaker" });
                await _database.AddHeroAsync(new DotaHero { Name = "Juggernaut", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/juggernaut.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/juggernaut" });
                await _database.AddHeroAsync(new DotaHero { Name = "Mirana", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/mirana.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/mirana" });
                await _database.AddHeroAsync(new DotaHero { Name = "Morphling", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/morphling.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/morphling" });
                await _database.AddHeroAsync(new DotaHero { Name = "Nevermore", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/nevermore.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/shadowfiend" });
                await _database.AddHeroAsync(new DotaHero { Name = "Phantom Lancer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phantom_lancer.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/phantomlancer" });
                await _database.AddHeroAsync(new DotaHero { Name = "Puck", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/puck.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/puck" });
                await _database.AddHeroAsync(new DotaHero { Name = "Pudge", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pudge.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/pudge" });
                await _database.AddHeroAsync(new DotaHero { Name = "Razor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/razor.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/razor" });
                await _database.AddHeroAsync(new DotaHero { Name = "Sand King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sand_king.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/sandking" });
                await _database.AddHeroAsync(new DotaHero { Name = "Storm Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/storm_spirit.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/stormspirit" });
                await _database.AddHeroAsync(new DotaHero { Name = "Sven", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sven.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/sven" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tiny", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tiny.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/tiny" });
                await _database.AddHeroAsync(new DotaHero { Name = "Vengefulspirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/vengefulspirit.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/vengefulspirit" });
                await _database.AddHeroAsync(new DotaHero { Name = "Windrunner", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/windrunner.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/windranger" });
                await _database.AddHeroAsync(new DotaHero { Name = "Zeus", IconUrl = "https://static.wikia.nocookie.net/dota2_gamepedia/images/3/3f/Zeus_icon.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/zeus" });
                await _database.AddHeroAsync(new DotaHero { Name = "Kunkka", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/kunkka.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/kunkka" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lina", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lina.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/lina" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lich", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lich.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/lich" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lion", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lion.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/lion" });
                await _database.AddHeroAsync(new DotaHero { Name = "Shadow Shaman", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shadow_shaman.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/shadowshaman" });
                await _database.AddHeroAsync(new DotaHero { Name = "Slardar", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/slardar.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/slardar" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tidehunter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tidehunter.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/tidehunter" });
                await _database.AddHeroAsync(new DotaHero { Name = "Witch Doctor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/witch_doctor.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/witchdoctor" });
                await _database.AddHeroAsync(new DotaHero { Name = "Riki", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/riki.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/riki" });
                await _database.AddHeroAsync(new DotaHero { Name = "Enigma", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/enigma.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/enigma" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tinker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tinker.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/tinker" });
                await _database.AddHeroAsync(new DotaHero { Name = "Sniper", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/sniper.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/sniper" });
                await _database.AddHeroAsync(new DotaHero { Name = "Necrolyte", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/necrolyte.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/necrophos" });
                await _database.AddHeroAsync(new DotaHero { Name = "Warlock", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/warlock.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/warlock" });
                await _database.AddHeroAsync(new DotaHero { Name = "Beastmaster", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/beastmaster.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/beastmaster" });
                await _database.AddHeroAsync(new DotaHero { Name = "Queenofpain", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/queenofpain.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/queenofpain" });
                await _database.AddHeroAsync(new DotaHero { Name = "Venomancer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/venomancer.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/venomancer" });
                await _database.AddHeroAsync(new DotaHero { Name = "Faceless Void", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/faceless_void.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/facelessvoid" });
                await _database.AddHeroAsync(new DotaHero { Name = "Skeleton King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/skeleton_king.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/wraithking" });
                await _database.AddHeroAsync(new DotaHero { Name = "Death Prophet", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/death_prophet.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/deathprophet" });
                await _database.AddHeroAsync(new DotaHero { Name = "Phantom Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phantom_assassin.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/phantomassassin" });
                await _database.AddHeroAsync(new DotaHero { Name = "Pugna", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pugna.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/pugna" });
                await _database.AddHeroAsync(new DotaHero { Name = "Templar Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/templar_assassin.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/templarassassin" });
                await _database.AddHeroAsync(new DotaHero { Name = "Viper", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/viper.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/viper" });
                await _database.AddHeroAsync(new DotaHero { Name = "Luna", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/luna.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/luna" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dragon Knight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dragon_knight.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/dragonknight" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dazzle", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dazzle.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/dazzle" });
                await _database.AddHeroAsync(new DotaHero { Name = "Clockwerk", IconUrl = "https://static.wikia.nocookie.net/dota2_gamepedia/images/d/d8/Clockwerk_icon.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/clockwerk" });
                await _database.AddHeroAsync(new DotaHero { Name = "Leshrac", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/leshrac.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/leshrac" });
                await _database.AddHeroAsync(new DotaHero { Name = "Furion", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/furion.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/nature'sprophet" });
                await _database.AddHeroAsync(new DotaHero { Name = "Life Stealer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/life_stealer.png", MainAttribute = "Strenght", InfoUrl = "https://www.dota2.com/hero/lifestealer" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dark Seer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dark_seer.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/darkseer" });
                await _database.AddHeroAsync(new DotaHero { Name = "Clinkz", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/clinkz.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/clinkz" });
                await _database.AddHeroAsync(new DotaHero { Name = "Omniknight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/omniknight.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/omniknight" });
                await _database.AddHeroAsync(new DotaHero { Name = "Enchantress", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/enchantress.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/enchantress" });
                await _database.AddHeroAsync(new DotaHero { Name = "Huskar", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/huskar.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/huskar" });
                await _database.AddHeroAsync(new DotaHero { Name = "Night Stalker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/night_stalker.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/nightstalker" });
                await _database.AddHeroAsync(new DotaHero { Name = "Broodmother", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/broodmother.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/broodmother" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bounty Hunter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bounty_hunter.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/bountyhunter" });
                await _database.AddHeroAsync(new DotaHero { Name = "Weaver", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/weaver.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/weaver" });
                await _database.AddHeroAsync(new DotaHero { Name = "Jakiro", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/jakiro.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/jakiro" });
                await _database.AddHeroAsync(new DotaHero { Name = "Batrider", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/batrider.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/batrider" });
                await _database.AddHeroAsync(new DotaHero { Name = "Chen", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/chen.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/chen" });
                await _database.AddHeroAsync(new DotaHero { Name = "Spectre", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/spectre.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/spectre" });
                await _database.AddHeroAsync(new DotaHero { Name = "Doom Bringer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/doom_bringer.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/doom" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ancient Apparition", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ancient_apparition.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/ancientapparition" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ursa", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ursa.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/ursa" });
                await _database.AddHeroAsync(new DotaHero { Name = "Spirit Breaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/spirit_breaker.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/spiritbreaker" });
                await _database.AddHeroAsync(new DotaHero { Name = "Gyrocopter", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/gyrocopter.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/gyrocopter" });
                await _database.AddHeroAsync(new DotaHero { Name = "Alchemist", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/alchemist.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/alchemist" });
                await _database.AddHeroAsync(new DotaHero { Name = "Invoker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/invoker.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/invoker" });
                await _database.AddHeroAsync(new DotaHero { Name = "Silencer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/silencer.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/silencer" });
                await _database.AddHeroAsync(new DotaHero { Name = "Obsidian Destroyer", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/obsidian_destroyer.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/outworlddestroyer" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lycan", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lycan.png", MainAttribute = "Strenght", InfoUrl = "https://www.dota2.com/hero/lycan" });
                await _database.AddHeroAsync(new DotaHero { Name = "Brewmaster", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/brewmaster.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/brewmaster" });
                await _database.AddHeroAsync(new DotaHero { Name = "Shadow Demon", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shadow_demon.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/shadowdemon" });
                await _database.AddHeroAsync(new DotaHero { Name = "Lone Druid", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/lone_druid.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/lonedruid" });
                await _database.AddHeroAsync(new DotaHero { Name = "Chaos Knight", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/chaos_knight.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/chaosknight" });
                await _database.AddHeroAsync(new DotaHero { Name = "Meepo", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/meepo.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/meepo" });
                await _database.AddHeroAsync(new DotaHero { Name = "Treant", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/treant.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/treantprotector" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ogre Magi", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ogre_magi.png", MainAttribute = "Strenght", InfoUrl = "https://www.dota2.com/hero/ogremagi" });
                await _database.AddHeroAsync(new DotaHero { Name = "Undying", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/undying.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/undying" });
                await _database.AddHeroAsync(new DotaHero { Name = "Rubick", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/rubick.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/rubick" });
                await _database.AddHeroAsync(new DotaHero { Name = "Disruptor", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/disruptor.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/disruptor" });
                await _database.AddHeroAsync(new DotaHero { Name = "Nyx Assassin", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/nyx_assassin.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/nyxassassin" });
                await _database.AddHeroAsync(new DotaHero { Name = "Naga Siren", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/naga_siren.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/nagasiren" });
                await _database.AddHeroAsync(new DotaHero { Name = "Keeper of The Light", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/keeper_of_the_light.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/keeperofthelight" });
                await _database.AddHeroAsync(new DotaHero { Name = "Wisp", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/wisp.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/io" });
                await _database.AddHeroAsync(new DotaHero { Name = "Slark", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/slark.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/slark" });
                await _database.AddHeroAsync(new DotaHero { Name = "Medusa", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/medusa.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/medusa" });
                await _database.AddHeroAsync(new DotaHero { Name = "Troll Warlord", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/troll_warlord.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/trollwarlord" });
                await _database.AddHeroAsync(new DotaHero { Name = "Centaur", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/centaur.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/centaurwarrunner" });
                await _database.AddHeroAsync(new DotaHero { Name = "Magnus", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/magnataur.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/magnus" });
                await _database.AddHeroAsync(new DotaHero { Name = "Timbersaw", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/shredder.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/timbersaw" });
                await _database.AddHeroAsync(new DotaHero { Name = "Bristleback", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/bristleback.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/bristleback" });
                await _database.AddHeroAsync(new DotaHero { Name = "Tusk", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/tusk.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/tusk" });
                await _database.AddHeroAsync(new DotaHero { Name = "Skywrath Mage", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/skywrath_mage.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/skywrathmage" });
                await _database.AddHeroAsync(new DotaHero { Name = "Abaddon", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/abaddon.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/abaddon" });
                await _database.AddHeroAsync(new DotaHero { Name = "Elder Titan", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/elder_titan.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/eldertitan" });
                await _database.AddHeroAsync(new DotaHero { Name = "Legion Commander", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/legion_commander.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/legioncommander" });
                await _database.AddHeroAsync(new DotaHero { Name = "Techies", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/techies.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/techies" });
                await _database.AddHeroAsync(new DotaHero { Name = "Ember Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/ember_spirit.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/emberspirit" });
                await _database.AddHeroAsync(new DotaHero { Name = "Earth Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/earth_spirit.png", MainAttribute = "Strenght", InfoUrl = "https://www.dota2.com/hero/earthspirit" });
                await _database.AddHeroAsync(new DotaHero { Name = "Terrorblade", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/terrorblade.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/terrorblade" });
                await _database.AddHeroAsync(new DotaHero { Name = "Phoenix", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/phoenix.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/phoenix" });
                await _database.AddHeroAsync(new DotaHero { Name = "Oracle", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/oracle.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/oracle" });
                await _database.AddHeroAsync(new DotaHero { Name = "Winter Wyvern", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/winter_wyvern.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/winterwyvern" });
                await _database.AddHeroAsync(new DotaHero { Name = "Arc Warden", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/arc_warden.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/arcwarden" });
                await _database.AddHeroAsync(new DotaHero { Name = "Monkey King", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/monkey_king.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/monkeyking" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dark Willow", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dark_willow.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/darkwillow" });
                await _database.AddHeroAsync(new DotaHero { Name = "Pangolier", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/pangolier.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/pangolier" });
                await _database.AddHeroAsync(new DotaHero { Name = "Grimstroke", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/grimstroke.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/grimstroke" });
                await _database.AddHeroAsync(new DotaHero { Name = "Hoodwink", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/hoodwink.png", MainAttribute = "Agility", InfoUrl = "https://www.dota2.com/hero/hoodwink" });
                await _database.AddHeroAsync(new DotaHero { Name = "Void Spirit", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/void_spirit.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/voidspirit" });
                await _database.AddHeroAsync(new DotaHero { Name = "Snapfire", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/snapfire.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/snapfire" });
                await _database.AddHeroAsync(new DotaHero { Name = "Mars", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/mars.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/mars" });
                await _database.AddHeroAsync(new DotaHero { Name = "Dawnbreaker", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/dawnbreaker.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/dawnbreaker" });
                await _database.AddHeroAsync(new DotaHero { Name = "Marci", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/marci.png", MainAttribute = "Universal", InfoUrl = "https://www.dota2.com/hero/marci" });
                await _database.AddHeroAsync(new DotaHero { Name = "Primal Beast", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/primal_beast.png", MainAttribute = "Strength", InfoUrl = "https://www.dota2.com/hero/primalbeast" });
                await _database.AddHeroAsync(new DotaHero { Name = "Muerta", IconUrl = "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/heroes/muerta.png", MainAttribute = "Intelligence", InfoUrl = "https://www.dota2.com/hero/muerta" });
            }

            _allHeroes = await _database.GetHeroesAsync();
            GenerateHeroButtons(_allHeroes);
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
                    Aspect = Aspect.AspectFill,
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

        private async void OnHeroSelected(DotaHero hero)
        {
            await Navigation.PushAsync(new HeroDetailPage(hero));
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
