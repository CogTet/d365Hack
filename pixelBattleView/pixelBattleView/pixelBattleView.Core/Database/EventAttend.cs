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
        public Contact Contact => GetForeign<Contact>("spieler");

        public EventAttend(Entity entity, IOrganizationService service) : base(entity, service)
        {
        }
    }
}
