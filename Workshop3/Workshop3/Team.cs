using System;
using Workshop3DAL;

namespace Workshop3Logic
{
    public class Team
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string MainSponser { get; set; }
        public int FoundYear { get; set; }
        public string Director { get; set; }

        public Team(TeamDTO teamDTO)
        {
            Name = teamDTO.Name;
            City = teamDTO.City;
            Country = teamDTO.Country;
            MainSponser = teamDTO.MainSponser;
            FoundYear = teamDTO.FoundYear;
            Director = teamDTO.Director;
        }

        public Team()
        {

        }

        public void UpdateTeam(Team team)
        {
            // return team;
        }
    }

    
}
