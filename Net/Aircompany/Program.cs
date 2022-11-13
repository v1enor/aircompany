using System.IO;

namespace Aircompany
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var airport = new Airport(PlaneRegistry.Planes);
            var militaryAirport = new Airport(airport.GetMilitaryPlanes());
            var passengerAirport = new Airport(airport.GetPassengersPlanes());
            using (var writer = new StreamWriter("ConsoleOutput.txt"))
            {
                writer.WriteLine(militaryAirport.SortPlanesByMaxFlightDistance().ToString());
                writer.WriteLine(passengerAirport.SortPlanesByMaxSpeed().ToString());
                writer.WriteLine(passengerAirport.GetPassengerPlaneWithMaxPassengersCapacity());
            }
        }
    }
}