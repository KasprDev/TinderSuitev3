using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using TinderSuitev3.Helpers;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3.Windows
{
    /// <summary>
    /// Interaction logic for ViewProfile.xaml
    /// </summary>
    public partial class ViewProfile : Window, INotifyPropertyChanged
    {
        private static string? UserId { get; set; }
        public static TinderUser? Profile;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
            OnPropertyChanged("Profile");
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
