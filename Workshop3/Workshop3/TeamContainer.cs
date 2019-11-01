using System;
using System.Collections.Generic;
using System.Text;
using WorkShopInterface;
using Workshop3DAL;

namespace Workshop3Logic
{
    public class TeamContainer
    {
        public List<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
        ITeamContainerDAL<TeamDTO> TeamContainerDALOBJ = new TeamDAL();
        public TeamDTO StoredTeam { get; set; }

        public List<Team> GetAllTeams()
        {
            Teams = TeamContainerDALOBJ.GetAllTs();
            List<Team> teams = new List<Team>();
            Teams.ForEach(
                    x =>
                    {
                        Team team = new Team(x);
                        teams.Add(team);
                    }
                );
            return teams;
        }

        public Team GetTeam(int teamID)
        {
            StoredTeam = TeamContainerDALOBJ.GetTByID(1);
            Team Testteam = new Team(StoredTeam);
            return Testteam;
        }
    }
}
