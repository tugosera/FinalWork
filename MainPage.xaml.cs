using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace FinalWork
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            UpdateAuthButtons();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateAuthButtons();
        }

        private void UpdateAuthButtons()
        {
            bool isLoggedIn = Preferences.Get("IsLoggedIn", false);

            LoginButton.IsVisible = !isLoggedIn;
            LogoutButton.IsVisible = isLoggedIn;
            BottomButton.IsVisible = isLoggedIn;
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

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            Preferences.Set("IsLoggedIn", false);
            UpdateAuthButtons();
        }
    }
}
