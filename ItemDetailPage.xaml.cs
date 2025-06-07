using Microsoft.Maui.Controls;

namespace FinalWork
{
    public partial class ItemDetailPage : ContentPage
    {
        private DotaItem _item;

        public ItemDetailPage(DotaItem item)
        {
            InitializeComponent();

            _item = item;

            ItemIcon.Source = _item.IconUrl;
            ItemName.Text = _item.Name;

            if (!string.IsNullOrWhiteSpace(_item.InfoUrl))
            {
                var url = _item.InfoUrl.Trim();
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    url = "https://" + url;

                ItemWebView.Source = url;
            }
            else
            {
                ItemWebView.Source = new HtmlWebViewSource
                {
                    Html = "<html><body><h3>Информация отсутствует</h3></body></html>"
                };
            }
        }
    }
}