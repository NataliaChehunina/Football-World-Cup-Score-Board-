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

        public GameIsNotFoundException(string gameID)
            : base($"Game with ID {gameID} is not found")
        {

        }
    }
}
