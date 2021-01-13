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
            //CollectionAssert.AreEqual();
        }

        [TestMethod]
        public void TestSameTeamNames()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<InvalidInputParametersException>(() => board.StartGame("Italy", "Italy"));
        }

        [TestMethod]
        public void TestEmptyInputs()
        {
            Scoreboard board = new Scoreboard();
            Assert.ThrowsException<InvalidInputParametersException>(() => board.StartGame("", null));
        }
    }
}
