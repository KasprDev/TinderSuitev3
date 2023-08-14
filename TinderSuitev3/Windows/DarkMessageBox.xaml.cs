using System.Media;
using System.Windows;

namespace TinderSuitev3
{
    /// <summary>
    /// Interaction logic for DarkMessageBox.xaml
    /// </summary>
    public partial class DarkMessageBox : Window
    {
        private readonly string? _title;
        private readonly string _message;

        public DarkMessageBox(string message, string? title = null)
        {
            _title = title;
            _message = message;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
            MessageLabel.Text = _message;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
