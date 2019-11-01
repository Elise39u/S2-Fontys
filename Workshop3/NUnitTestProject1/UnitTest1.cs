using NUnit.Framework;
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
            TeamContainer teamContainer = new TeamContainer();
        }

        [Test]
        public void TestGetAllTeamsFromDatabase()
        {
            TeamContainer teamContainer = new TeamContainer();
            List<Team> teams = new List<Team>();
            TeamDTO teamDto = new TeamDTO
                {
                    Name = "Ferrari",
                    City = "Rome",
                    FoundYear = 1998,
                    Country = "Italty",
                    MainSponser = "Philps",
                    Director = "Justin van de laar"
                };
            teams = teamContainer.GetAllTeams();

            Assert.AreEqual(teamDto.Name, teams[0].Name);
            Assert.AreEqual(teamDto.Director, teams[0].Director);
            Assert.AreEqual(1, teams.Count);
        }
    }
}