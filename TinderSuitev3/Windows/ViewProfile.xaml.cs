using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3.Windows
{
    public partial class ViewProfile : Window
    {
        private static string? UserId { get; set; }
        public static TinderUser? Profile;

        public ViewProfile(string? userId)
        {
            InitializeComponent();
            UserId = userId;
            DataContext = this;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Profile = (await Tinder.Instances.First().GetMatchProfile(UserId!))!.Results;
            PersonName.Text = Profile.Name + $" ({CalculateAge(Profile.BirthDate)})";
            PersonBio.Text = Profile.Bio;

            RealPersonMeter.Value = Engine.ScoreUser(Profile);

            Distance.Text = Profile.DistanceMi.ToString() + " miles away";
            UserPhoto.Source =
                ImageHelper.BytesToBitmap(await ImageHelper.DownloadImage(Profile.Photos.First().Url, false));
        }

        /// <summary>
        /// Calculate the user's age based on their birthday.
        /// </summary>
        /// <param name="birthDate">The user's birthday.</param>
        /// <returns>The user's age in years.</returns>
        public static int CalculateAge(DateTime birthDate)
        {
            var currentDate = DateTime.Today;
            var age = currentDate.Year - birthDate.Year;

            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
