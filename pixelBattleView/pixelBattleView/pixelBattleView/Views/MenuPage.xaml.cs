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

namespace pixelBattleView.Views
{
    /// <summary>
    /// Interaktionslogik für MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public event RoutedEventHandler FunButtonClicked;
        public event RoutedEventHandler BattleButtonClicked;
        public event RoutedEventHandler GameButtonClicked;
        public MenuPage()
        {
            InitializeComponent();
            FunBtn.Click += (s,e) => FunButtonClicked?.Invoke(s,e);
            BattleBtn.Click += (s, e) => BattleButtonClicked?.Invoke(s, e);
            GameBtn.Click += (s, e) => GameButtonClicked?.Invoke(s, e);

        }
        
    }
}
