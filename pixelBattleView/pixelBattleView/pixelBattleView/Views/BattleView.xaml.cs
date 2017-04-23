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
using pixelBattleView.Core.Database;
using pixelBattleView.Core;

namespace pixelBattleView.Views
{
    /// <summary>
    /// Interaktionslogik für BattleView.xaml
    /// </summary>
    public partial class BattleView : Page
    {
        private TournementPairing tournementPairing;
        private CRM crm;
        private LeagueAttend attend;

        public BattleView(CRM crm)
        {
            InitializeComponent();
            this.crm = crm;

            GetTounement();

            PlayerOneName.Text = tournementPairing?.Attend1.EventAttend.Contact.Name;
            PlayerTwoName.Text = tournementPairing?.Attend2.EventAttend.Contact.Name;
            LeagueName.Text = attend?.League.Name;
            EventLable.Text = attend?.League.Event.Name;
            

        }

        private void GetTounement()
        {
            attend = crm.GetLeagueAttends().Where(l => l.Status == GameStatus.Pending).FirstOrDefault();
            tournementPairing = crm.GetTournemtPairings().Where(t => t.Attend1.Status == GameStatus.Pending || t.Attend2.Status == GameStatus.Pending).FirstOrDefault();

        }
    }
}
