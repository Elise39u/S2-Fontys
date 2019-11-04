using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkShopInterface;

namespace Workshop3DAL
{
    public class TeamDAL : ITeam<TeamDTO>, ITeamContainerDAL<TeamDTO>
    {
        public List<TeamDTO> teamDTOs = new List<TeamDTO>();
        public bool CheckFlag = false;

        List<TeamDTO> ITeamContainerDAL<TeamDTO>.GetAllTs()
        {
            SetUP();
            return teamDTOs;
        }

        TeamDTO ITeamContainerDAL<TeamDTO>.GetTByID(int id)
        {
            SetUP();
            TeamDTO teamDto = new TeamDTO();
            for(int i = 0; i < teamDTOs.Count(); i++)
            {
                if (CheckFlag == true)
                {
                    break;
                }
                else
                {
                    if (i == id)
                    {
                        teamDto = teamDTOs[i];
                        CheckFlag = true;
                    }
                }
            }
            CheckFlag = false;
            return teamDto;
        }

        TeamDTO ITeam<TeamDTO>.UpdateTeam(TeamDTO t, int id)
        {
            SetUP();
            teamDTOs.Remove(teamDTOs[id]);
            teamDTOs.Add(t);
            return teamDTOs.Last();
        }

        public void SetUP()
        {

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

            teamDto = new TeamDTO
            {
                Name = "Mercedes",
                City = "Londen",
                FoundYear = 1981,
                Country = "England",
                MainSponser = "Red Bull",
                Director = "Justin Rijgersberg"
            };
            teamDTOs.Add(teamDto);

            for (int i = 0; i < 10; i++)
            {
                TeamDTO teamDTO = new TeamDTO();
                teamDTOs.Add(teamDTO);
            }
        }
    }
}
