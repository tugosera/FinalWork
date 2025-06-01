using Microsoft.Maui.Controls;

namespace FinalWork
{
    public partial class HeroDetailPage : ContentPage
    {
        private DotaHero _hero;

        public HeroDetailPage(DotaHero hero)
        {
            InitializeComponent();

            _hero = hero;

            // Устанавливаем изображение героя
            HeroIcon.Source = _hero.IconUrl;

            // Устанавливаем имя героя
            HeroName.Text = _hero.Name;

            // Выбираем иконку атрибута героя по его MainAttribute
            switch (_hero.MainAttribute?.ToLower())
            {
                case "strength":
                    AttributeIcon.Source = "strength_icon.png"; // Иконка силы
                    break;
                case "agility":
                    AttributeIcon.Source = "agility_icon.png";  // Иконка ловкости
                    break;
                case "intelligence":
                    AttributeIcon.Source = "intelligence_icon.png"; // Иконка интеллекта
                    break;
                case "universal":
                    AttributeIcon.Source = "universal_icon.png"; // Иконка универсального
                    break;
                default:
                    AttributeIcon.Source = null;
                    break;
            }

            // Загружаем URL в WebView или показываем сообщение, если ссылки нет
            if (!string.IsNullOrWhiteSpace(_hero.InfoUrl))
            {
                var url = _hero.InfoUrl.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = "https://" + url;

                HeroWebView.Source = url;
            }
            else
            {
                HeroWebView.Source = new HtmlWebViewSource
                {
                    Html = "<html><body><h3>Информация отсутствует</h3></body></html>"
                };
            }
        }
        
    }
}