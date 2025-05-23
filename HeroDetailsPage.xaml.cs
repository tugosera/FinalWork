using Microsoft.Maui.Controls;

namespace FinalWork
{
    public partial class HeroDetailsPage : ContentPage
    {
        public HeroDetailsPage(DotaHero hero)
        {
            InitializeComponent();

            HeroImage.Source = hero.IconUrl;
            HeroNameLabel.Text = hero.Name;
            HeroAttributeLabel.Text = $"???????? ???????: {hero.MainAttribute}";
        }
    }
}