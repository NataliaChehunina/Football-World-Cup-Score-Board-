using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            System.Threading.Thread.Sleep(20);
            
            id = board.StartGame("Argentina", "Uruguay");
            board.UpdateScore(id, 2, 3);
            System.Threading.Thread.Sleep(20);

            id = board.StartGame("Italy", "England");
            board.UpdateScore(id, 2, 2);
            System.Threading.Thread.Sleep(20);

            id = board.StartGame("Italy", "Sweden");
            board.UpdateScore(id, 3, 2);
            System.Threading.Thread.Sleep(20);

            id = board.StartGame("France", "USA");
            board.UpdateScore(id, 5, 1);

            resultList.Add($"France 5 - USA 1");
            resultList.Add($"Italy 3 - Sweden 2");
            resultList.Add($"Argentina 2 - Uruguay 3");
            resultList.Add($"Italy 2 - England 2");
            resultList.Add($"Germany 2 - Brazil 1");

            var elem = board.GetSummary();
            CollectionAssert.AreEqual(elem, resultList);
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
            Assert.ThrowsException<GameIsNotFoundException>(() => board.FinishGame("123"));
        }

        [TestMethod]
        public void TestFinishGame()
        {
            Scoreboard board = new Scoreboard();
            List<Game> resultList = new List<Game>();

            string id = board.StartGame("Italy", "Brazil");
            resultList.Add(new Game("Italy", "Brazil", 0, 0, id));

            id = board.StartGame("Germany", "Spain");
            board.FinishGame(id);

            CollectionAssert.AreEqual(board.Matches, resultList);
        }

        [TestMethod]
        public void TestUpdateScoreEmptyList()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<EmptyCollectionException>(() => board.UpdateScore(new Guid().ToString(), 3, 0));
        }

        [TestMethod]
        public void TestUpdateScoreEmptyGameId()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<InvalidInputParametersException>(() => board.UpdateScore(String.Empty, 0, 1));
        }

        [TestMethod]
        public void TestUpdateScoreNonexistentGame()
        {
            Scoreboard board = new Scoreboard();
            board.StartGame("Spain", "Greece");
            Assert.ThrowsException<GameIsNotFoundException>(() => board.UpdateScore("123", 0, 2));
        }

        [TestMethod]
        public void TestUpdateScore()
        {
            Scoreboard board = new Scoreboard();
            List<Game> resultList = new List<Game>();

            string id = board.StartGame("Italy", "Brazil");
            board.UpdateScore(id, 1, 1);
            resultList.Add(new Game("Italy", "Brazil", 1, 1, id));

            id = board.StartGame("Germany", "Spain");
            board.UpdateScore(id, 2, 0);
            resultList.Add(new Game("Germany", "Spain", 2, 0, id));

            id = board.StartGame("Denmark", "Italy");
            board.UpdateScore(id, 0, 2);          
            resultList.Add(new Game("Denmark", "Italy", 0, 2, id));

            CollectionAssert.AreEqual(board.Matches, resultList);
        }

    }
}
