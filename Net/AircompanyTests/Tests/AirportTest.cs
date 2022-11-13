using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private readonly List<Plane> _planes = new List<Plane>(PlaneRegistry.Planes);
        private readonly PassengerPlane _planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242);
        private readonly List<Plane> _planesOrderedByMaxLoadCapacity = PlaneRegistry.Planes.OrderBy(x => x.GetMaxLoadCapacity()).ToList();
        [Test]
        public void DiscoveredTransportMilitaryPlanes()
        {
            var airport = new Airport(_planes);
            var transportMilitaryPlanes = airport.GetTransportMilitaryPlanes().ToList();
            Assert.IsTrue(transportMilitaryPlanes.Count != 0);
        }
        [Test]
        public void DiscoveredPassengerPlanesWithMaxPassengersCapacity()
        {
            var airport = new Airport(_planes);
            var supposedPlanesWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();
            Assert.IsTrue(supposedPlanesWithMaxPassengersCapacity.Equals(_planeWithMaxPassengerCapacity));
        }
        [Test]
        public void PlanesSortedByMaxLoadCapacity()
        {
            var airport = new Airport(_planes);
            var supposedPlanesSortedByMaxLoadCapacity = airport.SortPlanesByMaxLoadCapacity().GetPlanes().ToList();
            Assert.IsTrue(supposedPlanesSortedByMaxLoadCapacity.SequenceEqual(_planesOrderedByMaxLoadCapacity));
        }
    }
}