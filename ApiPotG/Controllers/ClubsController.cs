using ApiPotG.Models;
using System.Collections.Generic;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace ApiPotG.Controllers
{
    public class ClubsController : UmbracoApiController
    {
        // GET: api/Clubs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Clubs/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clubs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clubs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clubs/5
        public void Delete(int id)
        {
        }

        // eg. /umbraco/Api/Clubs/GetClub?id=1071
        /* [System.Web.Http.HttpGet]
        public List<Club> GetClub(int id)
        {
            var cs = Services.ContentService;
            List<Club> res = new List<Club>();
            var clubs = cs.GetChildren(id);

            List<Team> teams = tc.GetTeams(club.Id);
            new Club( var club in clubs);
            {
                Id = club.Id,
                Name = club.Properties["clubTitle"].Value.ToString(),
                Description = club.Properties["clubDescription"].Value.ToString(),
                Teams = teams
            };

        }*/
        // eg. /umbraco/Api/Clubs/GetClubs?id=1071
        [System.Web.Http.HttpGet]
        public List<Club> GetAllClubs(int id)
        {

            var cs = Services.ContentService;
            List<Club> allClubs = new List<Club>();
            var clubs = cs.GetChildren(id);
            var tc = new TeamController();

            foreach (var club in clubs)
            {
                List<Team> teams = tc.GetTeams(club.Id);

                var c = new Club
                {
                    Id = club.Id,
                    Name = club.Properties["clubTitle"].Value.ToString(),
                    Description = club.Properties["clubDescription"].Value.ToString(),
                    Teams = teams
                };
               allClubs.Add(c);
            }

            return allClubs;
        }
    }
}