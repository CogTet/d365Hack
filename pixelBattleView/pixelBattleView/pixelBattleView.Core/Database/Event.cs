using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelBattleView.Core.Database
{
    public class Event : CrmEntity
    {
        public DateTime DateFrom { get { return (DateTime)entity["rcc_datefrom"]; } set { entity["rcc_datefrom"] = value; } }
        public DateTime DateTo { get { return (DateTime)entity["rcc_dateto"]; } set { entity["rcc_dateto"] = value; } }
        public int Duration { get { return (int)entity["rcc_duration"]; } set { entity["rcc_duration"] = value; } }
        public string Name { get { return (string)entity["rcc_name"]; } set { entity["rcc_name"] = value; } }

        public Event(RCEntity entity, IOrganizationService service) : base(entity, service)
        {

        }
    }
}
