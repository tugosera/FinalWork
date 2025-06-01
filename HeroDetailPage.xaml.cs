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

            // ������������� ����������� �����
            HeroIcon.Source = _hero.IconUrl;

            // ������������� ��� �����
            HeroName.Text = _hero.Name;

            // �������� ������ �������� ����� �� ��� MainAttribute
            switch (_hero.MainAttribute?.ToLower())
            {
                case "strength":
                    AttributeIcon.Source = "strength_icon.png"; // ������ ����
                    break;
                case "agility":
                    AttributeIcon.Source = "agility_icon.png";  // ������ ��������
                    break;
                case "intelligence":
                    AttributeIcon.Source = "intelligence_icon.png"; // ������ ����������
                    break;
                case "universal":
                    AttributeIcon.Source = "universal_icon.png"; // ������ ��������������
                    break;
                default:
                    AttributeIcon.Source = null;
                    break;
            }

            // ��������� URL � WebView ��� ���������� ���������, ���� ������ ���
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
                    Html = "<html><body><h3>���������� �����������</h3></body></html>"
                };
            }
        }
        
    }
}