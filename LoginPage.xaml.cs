using SQLite;
using System;
using System.IO;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // ��� Preferences

namespace FinalWork
{
    public partial class LoginPage : ContentPage
    {
        private SQLiteAsyncConnection _db;

        public LoginPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<User>().Wait();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            var user = await _db.Table<User>().FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                Preferences.Set("IsLoggedIn", true);
                Preferences.Set("LoggedInUsername", user.Username);

                await DisplayAlert("�����", $"����� ����������, {user.Username}!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("������", "�������� ����� ��� ������", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text?.Trim();
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("������", "��������� ��� ����", "OK");
                return;
            }

            var existingUser = await _db.Table<User>().FirstOrDefaultAsync(u => u.Username == username);
            if (existingUser != null)
            {
                await DisplayAlert("������", "������������ ��� ����������", "OK");
                return;
            }

            var newUser = new User { Username = username, Password = password };
            await _db.InsertAsync(newUser);

            Preferences.Set("IsLoggedIn", true);
            Preferences.Set("LoggedInUsername", newUser.Username);

            await DisplayAlert("�����", "����������� ������ �������!", "OK");
            await Navigation.PopAsync();
        }

        public class User
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            [Unique]
            public string Username { get; set; }

            public string Password { get; set; }
        }
    }
}
