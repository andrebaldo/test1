using StarWarsTestKneat.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsTestKneat
{
    public interface IStarWarsApiWrapper
    {
        Task<StarshipsResult> getStarShipPage(string url);
    }
}
