using System;
using System.Collections.Generic;
using System.Text;
using WorkShopInterface;

namespace Workshop3DAL
{
    public class TeamDAL : ITeam<TeamDTO>, ITeamContainerDAL<TeamDTO>
    {
        List<TeamDTO> ITeamContainerDAL<TeamDTO>.GetAllTs()
        { 
            List<TeamDTO> teamDTOs = new List<TeamDTO>();
            TeamDTO teamDto = new TeamDTO
            {
                Name = "Ferrari",
                City = "Rome",
                FoundYear = 1998,
                Country = "Italty",
                MainSponser = "Philps",
                Director = "Justin van de laar"
            };
            teamDTOs.Add(teamDto);
            return teamDTOs;
            //throw new NotImplementedException();
        }

        TeamDTO ITeamContainerDAL<TeamDTO>.GetTByID(int id)
        {
            throw new NotImplementedException();
        }

        TeamDTO ITeam<TeamDTO>.UpdateTeam(TeamDTO t)
        {
            throw new NotImplementedException();
        }
    }
}
