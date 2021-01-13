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

        public Game(string homeTeamName, string awayTeamName, byte homeTeamScore, byte awayTeamScore)
        {
            GameId = new Guid().ToString();
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }
    }
}
