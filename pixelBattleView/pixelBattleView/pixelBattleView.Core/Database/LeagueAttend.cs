using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace pixelBattleView.Core.Database
{
    public class LeagueAttend : CrmEntity
    {
        public League League => GetForeign<League>("league");
        public EventAttend EventAttend => GetForeign<EventAttend>("eventattent");
        public GameStatus Status { get { return (GameStatus)((OptionSetValue)entity["statuscode"]).Value; } set { entity["statuscode"] = (int)value; } }

        public LeagueAttend(RCEntity entity, IOrganizationService service) : base(entity, service)
        {
        }

        
    }
}
