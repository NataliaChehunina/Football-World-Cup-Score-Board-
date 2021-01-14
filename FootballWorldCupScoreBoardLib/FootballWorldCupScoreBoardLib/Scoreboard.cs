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

        public string StartGame(string homeTeam, string awayTeam) //returns GameId; String.Empty - in case of failures
        {
            if (String.IsNullOrEmpty(homeTeam) || String.IsNullOrEmpty(awayTeam))
                throw new InvalidInputParametersException(homeTeam, awayTeam);
            if (homeTeam == awayTeam)
                throw new InvalidInputParametersException(homeTeam);
            return AddGame(homeTeam, awayTeam, 0, 0, Matches);
        }

        private string AddGame(string homeTeam, string awayTeam, byte homeTeamScore, byte awayTeamScore, List<IDisplayable> matches)
        {
            Game game = new Game(homeTeam, awayTeam, homeTeamScore, awayTeamScore);
            matches.Add(game);
            return game.GameId;
        }

        public bool UpdateScore(string gameId, byte homeTeamScore, byte awayTeamScore)
        {
            throw new NotImplementedException();
        }

        public bool FinishGame(string gameId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
