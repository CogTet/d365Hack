using pixelBattleView.Core;
using pixelBattleView.Core.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            Serializer.Serialize(new Configuration()
            {
                Uri = "https://d365hackkk.api.crm4.dynamics.com/XRMServices/2011/Organization.svc",
                Password = "Muenchen17!",
                Username = "Maximilian@d365hackkk.onmicrosoft.com",
                MediaSource = @"C:\Temp\Tetris.mp3"
            },
            @"C:\Temp\config.conf");
        }
    }
}
