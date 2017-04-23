using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace pixelBattleView.Core.Database
{
    public class League : CrmEntity
    {
        public Event Event => GetForeign<Event>("event");

        public string Description { get { return (string)entity["rcc_description"]; } set { entity["rcc_description"] = value; } }
        public string Name { get { return (string)entity["rcc_name"]; } set { entity["rcc_name"] = value; } }
        public DateTime DateFrom { get { return (DateTime)entity["rcc_datefrom"]; } set { entity["rcc_datefrom"] = value; } }
        public DateTime DateTo { get { return (DateTime)entity["rcc_dateto"]; } set { entity["rcc_dateto"] = value; } }
        public int Modus { get { return ((OptionSetValue)entity["rcc_modus"]).Value; } set { entity["rcc_modus"] = value; } }


        public League(RCEntity entity, IOrganizationService service) : base(entity, service)
        {

        }
    }
}
