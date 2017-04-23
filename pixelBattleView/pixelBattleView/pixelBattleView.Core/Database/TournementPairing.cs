using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace pixelBattleView.Core.Database
{
    public class TournementPairing : CrmEntity
    {
        public LeagueAttend Attend1 => GetForeign<LeagueAttend>("attendee1");
        public LeagueAttend Attend2 => GetForeign<LeagueAttend>("attendee2");
        public int Hirarchy { get { return (int)entity["rcc_hirarchy"]; } set { entity["rcc_hirarchy"] = value; } }
        public int Index { get { return (int)entity["rcc_index"]; } set { entity["rcc_index"] = value; } }


        public TournementPairing(RCEntity entity, IOrganizationService service) : base(entity, service)
        {
        }
    }
}
