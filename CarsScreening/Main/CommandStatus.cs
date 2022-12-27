using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsScreening.Main
{
    public static class CommandStatus
    {
        public enum StatusOfCommands
        {
            succesfulCommand=0,
            failedCommand=1
        }
        public enum StatusOfPage
        {
            PageIsLoaded = 0,
            PageIsNotLoaded=1
        }
    }
}
