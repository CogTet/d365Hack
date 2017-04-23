using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace pixelBattleView.Core.Database
{
    public class Contact : CrmEntity
    {
        public string Name { get { return (string)entity["fullname"]; } set { entity["fullname"] = value; } }
        public string Twitter { get { return (string)entity["rcc_twitter"]; } set { entity["rcc_twitter"] = value; } }

        public Contact(Entity entity, IOrganizationService service) : base(entity, service)
        {
        }
    }
}
