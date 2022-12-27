using CarsScreening.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsScreening.Main
{
    public static class FixedVariables
    {
        public static string Html = "";
        public static string ErrorMessage = "";
        public static int pageCounter = 0;
        public static int DetailCounter = 0;
        public static CommandStatus.StatusOfCommands statusOfCommands;
        public static CommandStatus.StatusOfPage statusOfPage=CommandStatus.StatusOfPage.PageIsNotLoaded;
        public static List<CarItem> CarsList = new List<CarItem>();
        public static CarDetails  carDetails= new CarDetails();
        public static HomeDeliveryItem homeDelivery = new HomeDeliveryItem();
        public static bool ProcessIsDone = false;
    }
}
