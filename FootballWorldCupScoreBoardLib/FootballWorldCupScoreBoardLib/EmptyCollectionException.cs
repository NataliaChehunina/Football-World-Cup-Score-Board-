using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorldCupScoreBoardLib
{
    [Serializable]
    public class EmptyCollectionException: Exception
    {
        public EmptyCollectionException()
            : base($"Scoreboard is empty")
        {

        }
    }
}
