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
        protected RCEntity entity;
        protected IOrganizationService service;

        public CrmEntity(RCEntity entity, IOrganizationService service)
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

        public override string ToString() => $"{entity.Entity.LogicalName}";
    }
}
