using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelBattleView.Core.Database
{
    public class CRMCollection<T> : List<T> where T : CrmEntity
    {
        private IOrganizationService service;
        public CRMCollection(DataCollection<Entity> entity, IOrganizationService service)
        {
            this.service = service;

            foreach (var item in entity)
                Add((T)Activator.CreateInstance(typeof(T), item, service));

        }
    }
}
