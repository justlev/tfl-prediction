using System.Collections.Generic;

namespace StationBoard.Models
{
    public interface IStationBoard
    {
        void Announce(string message);

        void ShowNextArrivals(IEnumerable<string> arrivals);
    }
}