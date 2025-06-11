using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace FinalWork
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Сбросить статус авторизации при запуске приложения
            Preferences.Set("IsLoggedIn", false);
            Preferences.Remove("LoggedInUsername");

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
