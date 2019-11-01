using System;
using WorkShopInterface;

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
        ITeam<Team> TeamObj { get; set; }

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

        public Team UpdateTeam(Team team)
        {
            Team storageTeam = new Team();
            storageTeam = TeamObj.UpdateTeam(team);
            return storageTeam;
        }
    }
}
