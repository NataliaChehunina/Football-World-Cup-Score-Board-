using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    public class Game: IDisplayable
    {
        public string GameId { get; }
        public byte HomeTeamScore { set;get;}
        public byte AwayTeamScore { set; get;}
        public string HomeTeamName { get; } // Team name is immutable in the context of the one game
        public string AwayTeamName { get; }

        public Game(string homeTeamName, string awayTeamName, byte homeTeamScore, byte awayTeamScore, string gameId = "")
        {
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;

            if(gameId == String.Empty)
                GameId = new Guid().ToString();
            else
                GameId = gameId;

        }

        public override bool Equals(object obj)
        {
            Game game = obj as Game;

            if (game == null)
            {
                return false;
            }

            return game.GameId == this.GameId && game.HomeTeamName == this.HomeTeamName && 
                game.HomeTeamScore == this.HomeTeamScore && game.AwayTeamName == this.AwayTeamName && 
                game.AwayTeamScore == this.AwayTeamScore;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
