using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    public class Game : IDisplayable, IComparable<IDisplayable>
    {
        public string GameId { get; }
        public DateTime StartTime { get; }
        public byte HomeTeamScore { set;get;}
        public byte AwayTeamScore { set; get;}
        public string HomeTeamName { get; } // Team name is immutable in the context of the one game
        public string AwayTeamName { get; }

        public Game(string homeTeamName, string awayTeamName, byte homeTeamScore, byte awayTeamScore, string gameId)            
        {
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
            GameId = gameId;
            StartTime = DateTime.Now;
        }

        public Game(string homeTeamName, string awayTeamName, byte homeTeamScore, byte awayTeamScore)
            : this(homeTeamName, awayTeamName, homeTeamScore, awayTeamScore, Guid.NewGuid().ToString())
        {

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
                game.AwayTeamScore == this.AwayTeamScore;               //ignoring DateTime for testing purposes and to not implement test comparer for unit test
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(IDisplayable y)
        {
            if (this.HomeTeamScore + this.AwayTeamScore > y.AwayTeamScore + y.HomeTeamScore)
                return -1;

            if (this.HomeTeamScore + this.AwayTeamScore < y.AwayTeamScore + y.HomeTeamScore)
                return 1;
            
            return DateTime.Compare(y.StartTime, this.StartTime); 
        }

        public override string ToString()
        {
            return $"{HomeTeamName} {HomeTeamScore} - {AwayTeamName} {AwayTeamScore}";
        }
    }
}
