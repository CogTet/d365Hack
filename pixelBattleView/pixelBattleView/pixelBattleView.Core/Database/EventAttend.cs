using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace pixelBattleView.Core.Database
{
    public class EventAttend : CrmEntity
    {
        public Event Event => GetForeign<Event>("event");
        public Player Contact => GetForeign<Player>("spieler");

        public EventAttend(RCEntity entity, IOrganizationService service) : base(entity, service)
        {
        }
    }
}
