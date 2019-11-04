using System;
using Workshop3DAL;
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
        ITeam<TeamDTO> TeamObj = new TeamDAL();

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

        public Team UpdateTeam(TeamDTO teamDTO, int id)
        {
            TeamDTO storageTeam = new TeamDTO();
            storageTeam = TeamObj.UpdateTeam(teamDTO, id);

            Team team = new Team(storageTeam);
            return team;
        }
    }
}
