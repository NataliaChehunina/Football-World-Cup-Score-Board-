using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    [Serializable]
    public class GameIsNotFoundException: Exception
    {
        public GameIsNotFoundException()
        {

        }

        public GameIsNotFoundException(string GameID)
            : base($"Game with ID {GameID} is not found")
        {

        }
    }
}
