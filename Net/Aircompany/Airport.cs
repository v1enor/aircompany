using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private readonly List<Plane> _planes;
        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }
        public IEnumerable<PassengerPlane> GetPassengersPlanes()
        {
            return _planes.Where(t => t.GetType() == typeof(PassengerPlane)).Cast<PassengerPlane>().ToList();
        }
        public IEnumerable<MilitaryPlane> GetMilitaryPlanes()
        {
            return _planes.Where(t => t.GetType() == typeof(MilitaryPlane)).Cast<MilitaryPlane>().ToList();
        }
        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            var passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((w, x) => w.GetPassengersCapacity() > x.GetPassengersCapacity() ? w : x);
        }
        public IEnumerable<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            var militaryPlanes = GetMilitaryPlanes();
            return militaryPlanes.Where(plane => plane.GetPlaneType() == MilitaryType.Transport).ToList();
        }
        public Airport SortPlanesByMaxFlightDistance()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxFlightDistance()));
        }
        public Airport SortPlanesByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxSpeed()));
        }
        public Airport SortPlanesByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }
        public IEnumerable<Plane> GetPlanes()
        {
            return _planes;
        }
        public override string ToString()
        {
            return "Airport{" + "planes=" + string.Join(", ", _planes.Select(x => x.GetModel())) + '}';
        }
    }
}