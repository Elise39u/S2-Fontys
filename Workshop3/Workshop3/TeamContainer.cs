using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop3Logic
{
    public class TeamContainer
    {
        public List<Team> Teams { get; private set; } = new List<Team>();

        public List<Team> GetAllTeams()
        {
            return Teams;
        }
    }
}
