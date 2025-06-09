using Microsoft.Maui.Controls;
using System;
using System.Net.Http;

namespace FinalWork
{
    public partial class HeroDetailPage : ContentPage
    {
        private DotaHero _hero;

        public HeroDetailPage(DotaHero hero)
        {
            InitializeComponent();
            _hero = hero;

            HeroIcon.Source = _hero.IconUrl;
            HeroName.Text = _hero.Name;

            LoadHeroPage(_hero.InfoUrl);
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

                    // Надёжная проверка содержимого страницы
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
    }
}
