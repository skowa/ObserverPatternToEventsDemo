using System;
using System.Timers;

namespace ObserverPatternDemo.Implementation
{
    /// <summary>
    /// This is simulator of sending data.
    /// </summary>
    public class SendingDataForWeatherDataSimulator
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// The method that starts to send data to <paramref name="weatherData"/>.
        /// </summary>
        /// <param name="weatherData">
        /// The <see cref="WeatherData"/> instance new data to be sent to.
        /// </param>
        /// <param name="timer">
        /// The timer.
        /// </param>
        /// <param name="interval">
        /// The interval of <paramref name="timer"/>.Elapsed event repeating.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="timer"/> is null.
        /// </exception>
        public void StartGeneration(WeatherData weatherData, Timer timer, double interval)
        {
            if (timer == null)
            {
                throw new ArgumentNullException(nameof(timer));
            }

            timer = new Timer(interval);
            timer.Elapsed += (o, e) => GenerateAndSetWeatherInfo(weatherData);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        /// <summary>
        /// The method that stops to send data.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="timer"/> is null.
        /// </exception>
        public void StopGenerating(Timer timer)
        {
            if (timer == null)
            {
                throw new ArgumentNullException(nameof(timer));
            }

            timer.Stop();
            timer.Dispose();
        }

        private void GenerateAndSetWeatherInfo(WeatherData weatherData)
        {
            weatherData.CurrentWeatherInfo = new WeatherInfoEventArgs(_random.Next(40), _random.Next(100), _random.Next(50));
        }
    }
}