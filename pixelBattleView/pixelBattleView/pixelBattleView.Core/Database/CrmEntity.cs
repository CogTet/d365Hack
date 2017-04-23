using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelBattleView.Core.Database
{
    public abstract class CrmEntity
    {
        protected Entity entity;
        protected IOrganizationService service;

        public CrmEntity(Entity entity, IOrganizationService service)
        {
            this.entity = entity;
            this.service = service;
        }

        protected virtual T GetForeign<T>(string name) where T : CrmEntity
        {
            var leagueRef = (EntityReference)entity[$"rcc_{name}"];

            var ent = service.Retrieve(leagueRef.LogicalName, leagueRef.Id, new ColumnSet(true));
            return (T)Activator.CreateInstance(typeof(T), ent, service);
        }
    }
}
