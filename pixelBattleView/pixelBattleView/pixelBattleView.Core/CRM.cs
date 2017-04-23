using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using pixelBattleView.Core.Database;
using pixelBattleView.Core.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pixelBattleView.Core
{
    public class CRM
    {
        public IOrganizationService Service { get; private set; }
        public Configuration Configuration { get; set; }

        public CRM(Configuration configuration)
        {
            Configuration = configuration;
        }

        public void Authenticate()
        {
            var authCredentials = new AuthenticationCredentials();
            authCredentials.ClientCredentials.UserName.UserName = Configuration.Username;
            authCredentials.ClientCredentials.UserName.Password = Configuration.Password;

            var orgServiceManagement = ServiceConfigurationFactory.CreateManagement<IOrganizationService>(new Uri(Configuration.Uri));
            var tokenCredentials = orgServiceManagement.Authenticate(authCredentials);

            using (var serviceProxy = new OrganizationServiceProxy(orgServiceManagement, tokenCredentials.SecurityTokenResponse))
            {
                Service = serviceProxy;

            }


        }

        public CRMCollection<Event> GetEvents()=> new CRMCollection<Event>(GetData("rcc", "event"), Service);

        public CRMCollection<EventAttend> GetEventAttends() => new CRMCollection<EventAttend>(GetData("rcc", "eventattend"), Service);

        public CRMCollection<League> GetLeagues()=> new CRMCollection<League>(GetData("rcc", "league"), Service);

        public CRMCollection<LeagueAttend> GetLeagueAttends() => new CRMCollection<LeagueAttend>(GetData("rcc", "leagueattent"), Service);

        public CRMCollection<Game> GetGames() => new CRMCollection<Game>(GetData("rcc", "ergebnis"), Service);

        public CRMCollection<TournementPairing> GetTournemtPairings() => new CRMCollection<TournementPairing>(GetData("rcc", "tournamentpairings"), Service);

        public CRMCollection<Player> GetContacts() => new CRMCollection<Player>( GetData("contact"), Service);

        private DataCollection<Entity> GetData(string entityName)
        {

            var query = new QueryExpression($"{entityName}")
            {
                ColumnSet = new ColumnSet(true)
            };

            var leagueAttendents = Service.RetrieveMultiple(query);
            return leagueAttendents.Entities;
        }
        private DataCollection<Entity> GetData(string prefix, string entityName)
        {

            var query = new QueryExpression($"{prefix}_{entityName}")
            {
                ColumnSet = new ColumnSet(true)
            };

            var leagueAttendents = Service.RetrieveMultiple(query);
            return leagueAttendents.Entities;
           
        }

    }
}
