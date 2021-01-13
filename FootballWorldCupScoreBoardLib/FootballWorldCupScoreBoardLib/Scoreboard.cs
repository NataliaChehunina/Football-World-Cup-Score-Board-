using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    class Scoreboard
    {
        public List<IDisplayable> Matches;
        public Scoreboard (List<IDisplayable> matches)
        {
            Matches.AddRange(matches); //to avoid mutilation of the list
        }

        public string StartGame() //returns GameId; String.Empty - in case of failures
        { 
            throw new NotImplementedException();           
        }

        public bool UpdateScore()
        {
            throw new NotImplementedException();
        }

        public bool FinishGame()
        {
            throw new NotImplementedException();
        }

        public List<IDisplayable> GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
