using pixelBattleView.Core;
using pixelBattleView.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace pixelBattleView.Views
{
    /// <summary>
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameView : Page
    {
        Game game;
        private CRMCollection<Game> games;
        private Timer timer;
        private CRM crm;
        private Player contact;
        private CRMCollection<Player> contacts;
        private int oldCount;

        public GameView(CRM crm)
        {
            oldCount = 0;
            InitializeComponent();

            this.crm = crm;

            GetActualGame();

            HighScoreList.Width = Width / 3;



            timer = new Timer();
            timer.Interval = 500;

            timer.Elapsed += (s, e) =>
            {
                GetActualGame();
            };

            timer.Start();



        }

        private void GetActualGame()
        {
            try
            {

                games = crm.GetGames();
                contacts = crm.GetContacts();


                game = games.FirstOrDefault(g => g.Status == GameStatus.Running);
                contact = contacts.FirstOrDefault(p => p.Playing == true);


                if (game == null)
                    game = games.OrderByDescending(g => g.ModifiedOn).FirstOrDefault();

                if (contact == null)
                    contact = contacts.OrderByDescending(c => c.ModifiedOn).FirstOrDefault();

                if (oldCount != games.Count)
                {
                    HighScoreList.Dispatcher.Invoke(() =>
                    {
                        HighScoreList.Items.Clear();
                        foreach (var item in games.OrderByDescending(g => g.Points))
                        {
                            HighScoreList.Items.Add($"{HighScoreList.Items.Count + 1}. {item.Points} : {item.Name}");
                        }
                    });
                    oldCount = games.Count;
                }

                PlayerName.Dispatcher.Invoke(() =>
                {
                    PlayerTwitter.Dispatcher.Invoke(() =>
                    {
                        if (!contact.Playing) { 
                            PlayerName.Text = "Aktuell Spielt: niemand";
                            PlayerTwitter.Text = "";
                            UserImage.Source = null;
                        }
                        else
                        {
                            PlayerName.Text = $"Aktuell Spielt: {contact?.Name}";
                            PlayerTwitter.Text = $"Twitter: {contact?.Twitter}";



                            var image = contact.Image;
                            if (image != null)
                                UserImage.Source = image;
                            else
                                UserImage.Source = null;

                        }
                    });
                });

                // EventName.Text = game?.League.Event.Name;
            }
            catch { }

        }
    }
}
