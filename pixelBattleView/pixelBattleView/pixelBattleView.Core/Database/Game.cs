using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace pixelBattleView.Core.Database
{
    public class Game : CrmEntity
    {
        public League League => GetForeign<League>("leage");
        public Player Contact => GetForeign<Player>("spieler");
        public LeagueAttend LeagueAttend => GetForeign<LeagueAttend>("leagueattent");
        public int Duration { get { return (int)entity["rcc_dauer"]; } set { entity["rcc_dauer"] = value; } }
        public int Points { get { return (int)entity["rcc_punkte"]; } set { entity["rcc_punkte"] = value; } }
        public DateTime ModifiedOn { get { return (DateTime)entity["modifiedon"]; } set { entity["modifiedon"] = value; } }
        public string Name { get { return (string)entity["rcc_name"]; } set { entity["rcc_name"] = value; } }
        public GameStatus Status { get { return (GameStatus)((OptionSetValue)entity["statuscode"]).Value; } set { entity["statuscode"] = (int)value; } }

        public Game(RCEntity entity, IOrganizationService service) : base(entity, service)
        {
        }
        
    }
}
