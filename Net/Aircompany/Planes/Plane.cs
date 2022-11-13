using System.Collections.Generic;

namespace Aircompany.Planes
{
    public abstract class Plane
    {
        private readonly string _model;
        private readonly int _maxSpeed;
        private readonly int _maxFlightDistance;
        private readonly int _maxLoadCapacity;

        protected Plane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity)
        {
            _model = model;
            _maxSpeed = maxSpeed;
            _maxFlightDistance = maxFlightDistance;
            _maxLoadCapacity = maxLoadCapacity;
        }
        public string GetModel()
        {
            return _model;
        }
        public int GetMaxSpeed()
        {
            return _maxSpeed;
        }
        public int GetMaxFlightDistance()
        {
            return _maxFlightDistance;
        }
        public int GetMaxLoadCapacity()
        {
            return _maxLoadCapacity;
        }
        public override string ToString()
        {
            return "Plane{" + "model='" + _model + '\'' + ", maxSpeed=" + _maxSpeed + ", maxFlightDistance=" + _maxFlightDistance + ", maxLoadCapacity=" + _maxLoadCapacity + '}';
        }
        public override bool Equals(object obj)
        {
            return obj is Plane plane && _model == plane._model && _maxSpeed == plane._maxSpeed && _maxFlightDistance == plane._maxFlightDistance && _maxLoadCapacity == plane._maxLoadCapacity;
        }
        public override int GetHashCode()
        {
            var hashCode = -1043886837;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_model);
            hashCode = hashCode * -1521134295 + _maxSpeed.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxFlightDistance.GetHashCode();
            hashCode = hashCode * -1521134295 + _maxLoadCapacity.GetHashCode();
            return hashCode;
        }
    }
}