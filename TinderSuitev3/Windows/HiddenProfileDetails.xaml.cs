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
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using QuickType;

namespace TinderSuitev3.Windows
{
    /// <summary>
    /// Interaction logic for HiddenProfileDetails.xaml
    /// </summary>
    public partial class HiddenProfileDetails : Window
    {
        public static TinderUserDetails? Details { get; set; }
        public HiddenProfileDetails(TinderUserDetails details)
        {
            InitializeComponent();
            Details = details;
            DataContext = this;
        }
    }
}
