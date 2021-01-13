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
        public InvalidInputParametersException()
        {

        }

        public InvalidInputParametersException(string HomeTeamName, string AwayTeamName, byte HomeTeamScore, byte AwayTeamScore)
            : base
                (
                  $"Input parameters cannot be null or empty HomeTeamName = { HomeTeamName}, " + 
                  $"AwayTeamName = {AwayTeamName}, " +  
                  $"{HomeTeamScore}-{AwayTeamScore}"
                )
        {

        }

        public InvalidInputParametersException(string HomeTeamName)
             : base($"The team names are the same : {HomeTeamName} ")
        {

        }
    }
}
