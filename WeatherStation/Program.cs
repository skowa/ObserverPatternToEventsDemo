using System;
using System.Timers;
using ObserverPatternDemo.Implementation;
using ObserverPatternDemo.Implementation.Listeners;

namespace WeatherStation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            
            var currentReport = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            currentReport.Subscribe(weatherData);
            statisticReport.Subscribe(weatherData);

            var simulator = new SendingDataForWeatherDataSimulator();
            var timer = new Timer();
            weatherData.StartCheckingData(500);
            simulator.StartGeneration(weatherData, timer, 600);

            Console.WriteLine("Press enter to stop simulation");
            Console.ReadLine();

            simulator.StopGenerating(timer);
            weatherData.StopCheckingData();

            currentReport.Unsubscribe(weatherData);
            statisticReport.Unsubscribe(weatherData);

            Console.WriteLine(currentReport);
            Console.WriteLine(statisticReport);
        }
    }
}
