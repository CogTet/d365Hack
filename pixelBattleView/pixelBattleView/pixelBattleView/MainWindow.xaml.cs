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
        private Timer timer;
        private MenuState menuState;

        public MainWindow()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 10000;

            timer.Elapsed += (s, e) =>
            {
                GetActualGame();
            };

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
            menu.GameButtonClicked += (s, e) => Content = new GameView(crm.GetGames().FirstOrDefault());
            menu.BattleButtonClicked += (s, e) => Content = new BattleView(crm.GetTournemtPairings().FirstOrDefault());
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

        private void GetActualGame()
        {
            if (menuState != MenuState.Game)
                return;

            var games = crm.GetGames();
            var game = games.FirstOrDefault(g => g.Status == GameStatus.Pending);

            if (game == null)
                game = games.OrderByDescending(g => g.ModifiedOn).FirstOrDefault();
            
            Content = new GameView(game);
        }

    }
}
