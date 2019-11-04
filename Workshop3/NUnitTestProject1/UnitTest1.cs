using NUnit.Framework;
using System;
using System.Collections.Generic;
using Workshop3Logic;
using WorkShopInterface;

namespace Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestGetAllTeamsFromDatabase()
        {
            TeamContainer teamContainer = new TeamContainer();
            List<Team> teams = new List<Team>();
            teams = teamContainer.GetAllTeams();

            Assert.AreEqual("Ferrari", teams[0].Name);
            Assert.AreEqual("Justin van de laar", teams[0].Director);
            Assert.AreEqual(12, teams.Count);
        }

        [Test]
        public void GetATeamFromDatabaseById()
        {
            int id = 1;

            TeamContainer teamContainer = new TeamContainer();
            Team team = teamContainer.GetTeam(id);

            Assert.AreEqual("Mercedes", team.Name);
            Assert.AreEqual("Justin Rijgersberg", team.Director);

            id = 0;

            teamContainer = new TeamContainer();
            team = teamContainer.GetTeam(id);

            Assert.AreEqual("Ferrari", team.Name);
            Assert.AreEqual("Justin van de laar", team.Director);
        }

        [Test] 
        public void UpdateATeamInTheDatabase()
        {
            int teamId = 5;

            Team teamObj = new Team();
            TeamDTO newData = new TeamDTO
            {
                Name = "Volvo",
                City = "Hamburg",
                FoundYear = 1832,
                Country = "Germany",
                MainSponser = "Volkswagen",
                Director = "Sal der mister"
            };
            Team teamUpdate = teamObj.UpdateTeam(newData, teamId);;

            Assert.AreEqual("Volvo", teamUpdate.Name);
            Assert.AreEqual("Sal der mister", teamUpdate.Director);
        }
    }
}