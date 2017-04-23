using pixelBattleView.Core.Database;
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
    /// Interaktionslogik für GameView.xaml
    /// </summary>
    public partial class GameView : Page
    {
        Game game;

        public GameView(Game game)
        {
            InitializeComponent();

            this.game = game;

            if (game.Status != GameStatus.Running)
                Points.Text = "Aktuell läuft kein Spiel";
            else
                Points.Text = game.League.Event.Name;

            EventName.Text = game?.League.Event.Name;
            LeaugueName.Text = game?.League.Name;
        }
    }
}
