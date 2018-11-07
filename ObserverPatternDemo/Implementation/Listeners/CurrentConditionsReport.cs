using System;

namespace ObserverPatternDemo.Implementation.Listeners
{
    /// <summary>
    /// This is current conditions report class-listener.
    /// </summary>
    public class CurrentConditionsReport
    {
        private WeatherInfoEventArgs _currentWeatherInfo;

        /// <summary>
        /// Handles an event.
        /// </summary>
        /// <param name="sender">
        /// The object that is to raised notifications.
        /// </param>
        /// <param name="info">
        /// The current notification information.
        /// </param>
        public void Update(object sender, WeatherInfoEventArgs info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            _currentWeatherInfo = info?.Clone() ?? throw new ArgumentNullException(nameof(info));
        }

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
        /// Represents report about current weather.
        /// </summary>
        /// <returns>
        /// The instance of <see cref="CurrentConditionsReport"/> as a string.
        /// </returns>
        public override string ToString()
        {
            if (_currentWeatherInfo == null)
            {
                return "There is no data about current weather";
            }

            return
                "Current conditions report: " + 
                $"temperature is {_currentWeatherInfo.Temperature}, humidity is {_currentWeatherInfo.Humidity}, pressure is {_currentWeatherInfo.Pressure}";
        }
    }
}