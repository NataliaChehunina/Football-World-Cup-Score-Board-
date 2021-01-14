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
            if (matches is null)
                return String.Empty;
            Game game = new Game(homeTeam, awayTeam, homeTeamScore, awayTeamScore);
            matches.Add(game);
            return game.GameId;
        }

        public bool UpdateScore(string gameId, byte homeTeamScore, byte awayTeamScore)
        {
            if (String.IsNullOrEmpty(gameId))
                throw new InvalidInputParametersException();

            if (Matches.Count == 0)
                throw new EmptyCollectionException();

            int index = FindIndex(gameId, Matches);

            if (index == -2)
                return false;

            if (index == -1)
                throw new GameIsNotFoundException(gameId);

            IDisplayable game = (Game)Matches[index];
            Matches[index] = new Game(game.HomeTeamName, game.AwayTeamName, homeTeamScore, awayTeamScore, gameId);
            return true;
        }

        private int FindIndex(string gameId, List<IDisplayable> matches)
        {
            if (matches is null)
                return -2;

            return matches.FindIndex(elem => elem.GameId == gameId);
        }

        public bool FinishGame(string gameId)
        {
            if (String.IsNullOrEmpty(gameId))
                throw new InvalidInputParametersException();

            if (Matches.Count == 0)
                throw new EmptyCollectionException();

            int index = FindIndex(gameId, Matches);

            if (index == -2)
                return false;

            if (index == -1)
                throw new GameIsNotFoundException(gameId);

            Matches.RemoveAt(index);
            return true;
        }

        public List<string> GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
