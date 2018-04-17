using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace StarWarsTestKneat.DataModel
{
    public class Starship
    {
        public string name { get; set; }
        private string _consumables;

        public string consumables
        {
            get { return _consumables; }
            set { _consumables = value; }
        }

        private string _MGLT;

        public string MGLT
        {
            get { return _MGLT; }
            set { _MGLT = value; }
        }

        public int? getTotalConsumableInHours
        {
            get
            {
                string[] numbers = Regex.Split(consumables, @"\D+");
                int? result = null;
                if (numbers.Length > 0)
                {
                    int value = 0;
                    int.TryParse(numbers[0], out value);

                    if (_consumables.Contains("year"))
                    {
                        result = value * 365 * 24;
                    }
                    else if (_consumables.Contains("month"))
                    {
                        result = value * 30 * 24;
                    }
                    else if (_consumables.Contains("week"))
                    {
                        result = value * 7 * 24;
                    }
                    else if (_consumables.Contains("day"))
                    {
                        result = value * 24;
                    }

                }
                return result;
            }
        }
        public int? parsedMGLT
        {
            get
            {
                int result = 0;
                if (int.TryParse(_MGLT, out result))
                {
                    return result;
                }
                return null;
            }
        }

    }
}
