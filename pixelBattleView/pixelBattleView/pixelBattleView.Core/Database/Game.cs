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
        public League League => GetForeign<League>("league");
        public Contact Contact => GetForeign<Contact>("contact");
        public LeagueAttend LeagueAttend => GetForeign<LeagueAttend>("leagueattend");
        public int Duration { get { return (int)entity["rcc_duration"]; } set { entity["rcc_duration"] = value; } }
        public int Points { get { return (int)entity["rcc_points"]; } set { entity["rcc_points"] = value; } }
        public DateTime ModifiedOn { get { return (DateTime)entity["modifiedon"]; } set { entity["modifiedon"] = value; } }
        public GameStatus Status { get { return (GameStatus)((OptionSetValue)entity["status"]).Value; } set { entity["status"] = (int)value; } }

        public Game(Entity entity, IOrganizationService service) : base(entity, service)
        {
        }
        
    }
}
