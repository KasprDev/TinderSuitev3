using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;

namespace TinderSuitev3.Windows
{
    public partial class Messages : Window, INotifyPropertyChanged
    {
        public static TinderUser? User { get; set; }
        public Match[]? Inbox { get; set; }
        public Messages()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            User = await Tinder.Instances.First().GetUser();
            var resp = await Tinder.Instances.First().GetMatches(true);

            Inbox = resp?.Data.Matches?.ToArray();
            OnPropertyChanged("Inbox");
        }

        private void MessageListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var app = (Match)MessageListBox.Items[MessageListBox.SelectedIndex]!;
            new ViewMessageThread(app).Show();
        }
    }
}
