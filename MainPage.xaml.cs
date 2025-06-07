namespace FinalWork
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLeftTopClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Heroes());
        }

        private async void OnRightTopClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemPage());
        }

        private void OnBottomClicked(object sender, EventArgs e)
        {
            DisplayAlert("Кнопка нажата", "Вы нажали кнопку с логотипом Dota", "OK");
        }
    }

}
