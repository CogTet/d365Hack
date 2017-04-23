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

        public LeagueAttend(Entity entity, IOrganizationService service) : base(entity, service)
        {
        }

        
    }
}
