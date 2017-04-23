using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using pixelBattleView.Core;
using pixelBattleView.Core.Database;
using pixelBattleView.Core.JSON;
using pixelBattleView.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pixelBattleView
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CRM crm;
        private bool played;
        private MediaElement Korobeiniki;
        private Configuration configuration;

        public MainWindow()
        {
            InitializeComponent();
                       

            Content = new MenuPage();

            configuration = Serializer.Deserialize<Configuration>("", @"C:\Temp\config.conf");
            crm = new CRM(configuration);
            crm.Authenticate();

            ToMenu();

        }

        private void ToMenu()
        {
            var menu = new MenuPage();
            menu.FunButtonClicked += Menu_FunButtonClicked;
            menu.GameButtonClicked += (s, e) => Content = new GameView(crm);
            menu.BattleButtonClicked += (s, e) => Content = new BattleView(crm);
            MenuBtn.Click += (s, e) => ToMenu();
            Content = menu;
        }

        private void Menu_FunButtonClicked(object sender, RoutedEventArgs e)
        {
            played = !played;
            Korobeiniki = new MediaElement();
            Korobeiniki.Source = new Uri(configuration.MediaSource);
            Korobeiniki.LoadedBehavior = MediaState.Manual;

            Korobeiniki.Volume = 30;
            Korobeiniki.MediaEnded += (s, ev) =>
            {
                Korobeiniki.Position = TimeSpan.Zero;
                Korobeiniki.Play();
            };

            if (played)
            {
                Korobeiniki.Play();
            }
            else
            {
                Korobeiniki.Pause();
                Korobeiniki = null;
            }
        }

       

    }
}
