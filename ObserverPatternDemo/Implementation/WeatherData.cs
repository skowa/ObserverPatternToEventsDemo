using System;
using System.Timers;

namespace ObserverPatternDemo.Implementation
{
    /// <summary>
    /// This is weather data class-broadcaster.
    /// </summary>
    public class WeatherData
    {
        public event EventHandler<WeatherInfoEventArgs> NewWeatherInfo = delegate { };
        
        private WeatherInfoEventArgs _currentWeatherInfo = new WeatherInfoEventArgs();

        private WeatherInfoEventArgs _previousWeatherInfo = new WeatherInfoEventArgs();

        private Timer _timer;

        /// <summary>
        /// Gets or sets current weather info.
        /// </summary>
        internal WeatherInfoEventArgs CurrentWeatherInfo
        {
            get => _currentWeatherInfo;
            set => _currentWeatherInfo = value?.Clone() ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// The method that starts checking changing of <see cref="CurrentWeatherInfo"/>
        /// </summary>
        /// <param name="interval">
        /// The interval of repeating event.
        /// </param>
        public void StartCheckingData(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += (o, e) => CheckData();
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        /// <summary>
        /// The method that stops checking changing of <see cref="CurrentWeatherInfo"/>
        /// </summary>
        public void StopCheckingData()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        protected virtual void OnNewWeatherInfo(WeatherInfoEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            NewWeatherInfo(this, e);
        }

        private void CheckData()
        {
            if (!_previousWeatherInfo.Equals(CurrentWeatherInfo))
            {
                OnNewWeatherInfo(CurrentWeatherInfo);
                _previousWeatherInfo = CurrentWeatherInfo.Clone();
            }
        }
    }
}