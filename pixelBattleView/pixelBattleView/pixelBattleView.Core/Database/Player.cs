using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Xrm.Sdk.Query;

namespace pixelBattleView.Core.Database
{
    public class Player : CrmEntity
    {
        public string Name { get { return (string)entity["fullname"]; } set { entity["fullname"] = value; } }
        public string Twitter { get { return (string)entity["rcc_twitter"]; } set { entity["rcc_twitter"] = value; } }
        public bool Playing { get { return (bool)entity["rcc_playing"]; } set { entity["rcc_playing"] = value; } }
        public DateTime ModifiedOn { get { return (DateTime)entity["modifiedon"]; } set { entity["modifiedon"] = value; } }
        public int CountOfGames { get { return (int)entity["rcc_anzahlderspiele"]; } set { entity["rcc_anzahlderspiele"] = value; } }
        public BitmapImage Image => GetImage();

        public Player(RCEntity entity, IOrganizationService service) : base(entity, service)
        {
        }

        private BitmapImage GetImage()
        {
            var ent = service.Retrieve(entity.Entity.LogicalName, entity.Entity.Id, new ColumnSet("entityimage"));

            var buffer = (byte[])ent["entityimage"];

            if (buffer == null)
                return null;

            var bmap = new BitmapImage();
            bmap.BeginInit();
            bmap.CacheOption = BitmapCacheOption.OnLoad;

            
            using (var stream = new MemoryStream(buffer))
            {
                bmap.StreamSource = stream;
                bmap.EndInit();
                return bmap;
            }

            
        }
    }
}
