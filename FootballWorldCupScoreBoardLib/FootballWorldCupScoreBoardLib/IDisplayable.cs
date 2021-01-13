using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    public interface IDisplayable
    {
        string GameId { get; }
        byte HomeTeamScore { set; get; }
        byte AwayTeamScore { set; get; }
        string HomeTeamName { get; } // Team name is immutable in the context of the one game
        string AwayTeamName { get; }
    }
}
