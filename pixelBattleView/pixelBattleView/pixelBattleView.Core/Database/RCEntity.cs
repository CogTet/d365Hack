using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelBattleView.Core.Database
{
    public class RCEntity
    {
        public Entity Entity { get; private set; }

        public RCEntity(Entity entity)
        {
            Entity = entity;
        }

        public object this[string key]
        {
            get
            {
                if (Entity.Contains(key))
                    return Entity[key];
                else
                    return null;
            }
            set
            {
                Entity[key] = value;
            }
        }
    }
}
