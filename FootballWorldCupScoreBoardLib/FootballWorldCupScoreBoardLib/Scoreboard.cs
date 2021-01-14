using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    public class Scoreboard
    {
        public List<IDisplayable> Matches;

        public Scoreboard ()
        {
            Matches = new List<IDisplayable>();
        }
        public Scoreboard (List<IDisplayable> matches): base()
        {            
            Matches.AddRange(matches); //to avoid mutilation of the list
        }

        public string StartGame(string HomeTeam, string AwayTeam) //returns GameId; String.Empty - in case of failures
        { 
            throw new NotImplementedException();           
        }

        public bool UpdateScore(string GameId, byte HomeTeamScore, byte AwayTeamScore)
        {
            throw new NotImplementedException();
        }

        public bool FinishGame(string GameId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
