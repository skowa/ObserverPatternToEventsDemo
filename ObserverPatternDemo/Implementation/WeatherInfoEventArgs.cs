using System;

namespace ObserverPatternDemo.Implementation
{
    public sealed class WeatherInfoEventArgs : EventArgs, ICloneable, IEquatable<WeatherInfoEventArgs>
    {
        public WeatherInfoEventArgs() { }

        public WeatherInfoEventArgs(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

        public int Temperature { get; }
        public int Humidity { get; }
        public int Pressure { get; }

        public WeatherInfoEventArgs Clone() => new WeatherInfoEventArgs(Temperature, Humidity, Pressure);

        object ICloneable.Clone() => Clone();

        public bool Equals(WeatherInfoEventArgs other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Temperature == other.Temperature && Humidity == other.Humidity && Pressure == other.Pressure;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((WeatherInfoEventArgs) obj);
        }

        public override int GetHashCode()
        {
            return Temperature.GetHashCode() ^ Humidity.GetHashCode() ^ Pressure.GetHashCode();
        }
    }
}