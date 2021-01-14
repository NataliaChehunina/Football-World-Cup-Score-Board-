using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FootballWorldCupScoreBoardLib;

namespace FootballWorldCupScoreBoardLib.Tests
{
    [TestClass]
    public class FootballWorldCupScoreBoardLibTests
    {
        [TestMethod]
        public void TestStartGame()
        {
            Scoreboard board = new Scoreboard();
            List<Game> resultList = new List<Game>();

            string id = board.StartGame("France","Germany");
            resultList.Add(new Game ("France", "Germany", 0, 0, id));

            id = board.StartGame("Spain","Norway");
            resultList.Add(new Game("Spain", "Norway", 0, 0, id));

            CollectionAssert.AreEqual(board.Matches, resultList);
        }

        [TestMethod]
        public void TestStartGameSameTeamNames()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<InvalidInputParametersException>(() => board.StartGame("Italy", "Italy"));
        }

        [TestMethod]
        public void TestStartGameEmptyInputs()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<InvalidInputParametersException>(() => board.StartGame("", null));
        }

        [TestMethod]
        public void TestGetSummaryEmptyList()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<EmptyCollectionException>(() => board.GetSummary());
        }

        [TestMethod]
        public void TestGetSummary()
        {
            Scoreboard board = new Scoreboard();
            List<string> resultList = new List<string>();

            string id = board.StartGame("Germany","Brazil");
            board.UpdateScore(id, 2, 1);
            

            id = board.StartGame("Argentina", "Uruguay");
            board.UpdateScore(id, 3, 3);
            

            id = board.StartGame("Italy", "England");
            board.UpdateScore(id, 1, 2);
            

            id = board.StartGame("Italy", "Sweden");
            board.UpdateScore(id, 4, 2);

            resultList.Add($"Italy 4 - Sweden 2");
            resultList.Add($"Argentina 3 - Uruguay 3");
            resultList.Add($"Italy 1 - England 2");
            resultList.Add($"Germany 2 - Brazil 1");

            CollectionAssert.AreEqual(board.GetSummary(), resultList);
        }

        [TestMethod]
        public void TestFinishGameEmptyList()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<EmptyCollectionException>(() => board.FinishGame(new Guid().ToString()));
        }

        [TestMethod]
        public void TestFinishGameEmptyGameId()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<InvalidInputParametersException>(() => board.FinishGame(String.Empty));
        }

        [TestMethod]
        public void TestFinishGameNonexistentGame()
        {
            Scoreboard board = new Scoreboard();
            board.StartGame("Spain","Greece");
            Assert.ThrowsException<GameIsNotFoundException>(() => board.FinishGame(new Guid().ToString()));
        }
    }
}
