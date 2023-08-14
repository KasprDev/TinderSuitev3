using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TinderSuitev3.Objects;

namespace TinderSuitev3.UserControls
{
    /// <summary>
    /// Interaction logic for HiddenProfileField.xaml
    /// </summary>
    public partial class HiddenProfileField : UserControl
    {
        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(
            nameof(Key), typeof(string), typeof(HiddenProfileField), new PropertyMetadata("Default Text"));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value), typeof(string), typeof(HiddenProfileField), new PropertyMetadata("Default Text"));

        public string Key
        {
            get => (string)GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }

        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public HiddenProfileField()
        {
            InitializeComponent();
        }
    }
}
