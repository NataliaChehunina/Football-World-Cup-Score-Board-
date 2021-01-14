using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    public class Scoreboard
    {
        public List<Game> Matches;

        public Scoreboard()
        {
            Matches = new List<Game>();
        }
        public Scoreboard(List<Game> matches) : base()
        {
            Matches.AddRange(matches); //to avoid mutilation of the list
        }

        public string StartGame(string homeTeam, string awayTeam) //returns GameId
        {
            if (String.IsNullOrEmpty(homeTeam) || String.IsNullOrEmpty(awayTeam))
                throw new InvalidInputParametersException(homeTeam, awayTeam);

            if (homeTeam == awayTeam)
                throw new InvalidInputParametersException(homeTeam);

            return AddGame(homeTeam, awayTeam, 0, 0);
        }

        private string AddGame(string homeTeam, string awayTeam, byte homeTeamScore, byte awayTeamScore)
        {
            Game game = new Game(homeTeam, awayTeam, homeTeamScore, awayTeamScore);
            Matches.Add(game);
            return game.GameId;
        }

        public bool UpdateScore(string gameId, byte homeTeamScore, byte awayTeamScore)
        {
            if (String.IsNullOrEmpty(gameId))
                throw new InvalidInputParametersException();

            if (Matches.Count == 0 || Matches is null)
                throw new EmptyCollectionException();

            Game game = FindGameById(gameId);

            if (game is null)
                throw new GameIsNotFoundException(gameId);

            game.HomeTeamScore = homeTeamScore;
            game.AwayTeamScore = awayTeamScore;
            return true;
        }

        private Game FindGameById(string gameId)
        {
            return Matches.Find(elem => elem.GameId == gameId);
        }

        public bool FinishGame(string gameId)
        {
            if (String.IsNullOrEmpty(gameId))
                throw new InvalidInputParametersException();

            if (Matches.Count == 0 || Matches is null)
                throw new EmptyCollectionException();

            Game game = FindGameById(gameId);

            if (game is null)
                throw new GameIsNotFoundException(gameId);

            Matches.Remove(game);
            return true;
        }

        public List<string> GetSummary()
        {
            if (Matches.Count == 0)
                throw new EmptyCollectionException();

            Matches.Sort();
            return ConvertMatchesToString();         
        }

        private List<string> ConvertMatchesToString()
        {
            List<string> summary = new List<string>();

            foreach (Game game in Matches)
                summary.Add(game.ToString());
            return summary;                           
        }
     
    }
}
