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
using TinderSuitev3.Objects;
using TinderSuitev3.TinderEngine;
using TinderSuitev3.Windows;

namespace TinderSuitev3
{
    /// <summary>
    /// Interaction logic for Messages.xaml
    /// </summary>
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

        private void MessageListBox_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void MessageListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var app = (Match)MessageListBox.Items[MessageListBox.SelectedIndex]!;
            new ViewMessageThread(app).Show();
        }
    }
}
