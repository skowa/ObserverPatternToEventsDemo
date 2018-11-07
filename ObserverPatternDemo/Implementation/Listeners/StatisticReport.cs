using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPatternDemo.Implementation.Listeners
{
    /// <summary>
    /// This is weather condition statistics class-listener.
    /// </summary>
    public class StatisticReport
    {
        private readonly List<WeatherInfoEventArgs> _weatherInfoList = new List<WeatherInfoEventArgs>();

        /// <summary>
        /// The method that subscribes to the instance of <see cref="WeatherData"/>.
        /// </summary>
        /// <param name="weatherData">
        /// Instance of <see cref="WeatherData"/> to be subscribed to.
        /// </param>
        public void Subscribe(WeatherData weatherData)
        {
            if (weatherData == null)
            {
                throw new ArgumentNullException(nameof(weatherData));
            }

            weatherData.NewWeatherInfo += Update;
        }

        /// <summary>
        /// The method that unsubscribes from the instance of <see cref="WeatherData"/>. 
        /// </summary>
        /// <param name="weatherData">
        /// Instance of <see cref="WeatherData"/> to be unsubscribed from.
        /// </param>
        public void Unsubscribe(WeatherData weatherData)
        {
            if (weatherData == null)
            {
                throw new ArgumentNullException(nameof(weatherData));
            }

            weatherData.NewWeatherInfo -= Update;
        }

        /// <summary>
        /// Represents statistics of weather info.
        /// </summary>
        /// <returns>
        /// The instance of <see cref="StatisticReport"/> as a string.
        /// </returns>
        public override string ToString()
        {
            var report = new StringBuilder("Statistics:");
            foreach (WeatherInfoEventArgs info in _weatherInfoList)
            {
                report.Append(
                    $"\nTemperature is {info.Temperature}, humidity is {info.Humidity}, pressure is {info.Pressure}");
            }

            return report.ToString();
        }

        private void Update(object sender, WeatherInfoEventArgs info) => _weatherInfoList.Add(info.Clone());
    }
}
