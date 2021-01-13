using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    [Serializable]
    public class GameDuplicateException : Exception
    {
        public GameDuplicateException()
        {

        }

        public GameDuplicateException(string HomeTeamName, string AwayTeamName)
            : base($"Game between {HomeTeamName} and {AwayTeamName} is already added")
        {

        }
    }
}
