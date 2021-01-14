using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    [Serializable]
    public class InvalidInputParametersException : Exception
    {
        public InvalidInputParametersException():
            base("GameId is empty")
        {

        }

        public InvalidInputParametersException(byte homeTeamScore, byte awayTeamScore)
            : base
                (
                  $"Input parameters cannot be null or empty " + 
                  $"Home team score {homeTeamScore} - Away team score {awayTeamScore}"
                )
        {

        }

        public InvalidInputParametersException(string homeTeamName, string awayTeamName)
        : base
        (
          $"Input parameters cannot be null or empty: " +
          $"Home team name {homeTeamName} - Away team name {awayTeamName}"
        )
        {

        }

        public InvalidInputParametersException(string homeTeamName)
             : base($"The team names are the same : {homeTeamName} ")
        {

        }

    }
}
