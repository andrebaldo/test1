using StarWarsTestKneat.API;
using StarWarsTestKneat.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTestKneat
{
    public class Orchestration
    {
        public delegate void AllTasksFinishedDelegate();
        public event AllTasksFinishedDelegate AllTasksFinished;

        public void FecthSWServerData(string url, long totalDistance)
        {
            IStarWarsApiWrapper wrapper = new StarWarsApiWrapper();
            var starshipsTask = wrapper.getStarShipPage(url);

            starshipsTask.ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine("Something went wrong, check the internet conection.");
                    AllTasksFinished();
                    return;
                }

                PrintResultPage(task, totalDistance);
                if (task.Result.next != null && task.Result.next != string.Empty)
                {
                    FecthSWServerData(task.Result.next, totalDistance);
                    Console.Write("Please fecthing more data from server...\n");
                }
                else
                {
                    AllTasksFinished();
                }
            });
        }

        private void PrintResultPage(Task<StarshipsResult> task, long totalDistance)
        {
            foreach (var ship in ((StarshipsResult)task.Result).results)
            {
                bool success = false;
                var tconsumable = ship.getTotalConsumableInHours;
                if (tconsumable != null && tconsumable > 0)
                {
                    if (ship.parsedMGLT != null && ship.parsedMGLT > 0)
                    {
                        var totalStops = totalDistance / ship.parsedMGLT / tconsumable;
                        Console.WriteLine("Starship:{0} Total Stop(s):{1} --- Consumables:{2} MGLT:{3}", ship.name, totalStops, ship.consumables, ship.MGLT);
                        success = true;
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Something is wrong with this ship data: Ship:{0} Consumables:{1} MGLT:{2} can't calc.", ship.name, ship.consumables, ship.MGLT);
                }
            }
        }
    }


}

