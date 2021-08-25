using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amtrax_test_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// Static/Private Members or variables
        /// </summary>
        /// 
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly string sWeatherForecastKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Any unique Should be here, Even we can implement the random key generator for more restiction.
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Construct the Controller with dependency
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="memoryCache"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Return Weather Forecast Informations as Json Object
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            IEnumerable<WeatherForecast> listWeatherForecast = null;

            // If found in cache, return cached data
            if (_memoryCache.TryGetValue(sWeatherForecastKey, out listWeatherForecast))
            {
                return listWeatherForecast;
            }

            // If not found, then generate response
            listWeatherForecast = GetWeatherForecast();

            // Cache the Output and return same
            return SetAndGetCache(listWeatherForecast, 10);
        }

        /// <summary>
        /// Save and return Weather Forecast information
        /// </summary>
        /// <param name="foWeatherForecast"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<WeatherForecast> AddWeatherForecast(WeatherForecast foWeatherForecast)
        {
            List<WeatherForecast> listWeatherForecast = null;

            // If not found, then generate response
            bool bIsInMemory = _memoryCache.TryGetValue(sWeatherForecastKey, out listWeatherForecast);
            if (!bIsInMemory)
            {
                listWeatherForecast = GetWeatherForecast();
            }

            // Append new object in list
            listWeatherForecast.Add(foWeatherForecast);

            // Set cache and allot time duration again
            return SetAndGetCache(listWeatherForecast, 10);
        }

        /// <summary>
        /// Set cahce in Memory for a while and return Output
        /// </summary>
        /// <param name="listWeatherForecast"></param>
        /// <param name="inTimeInMinutes"></param>
        /// <returns></returns>
        private IEnumerable<WeatherForecast> SetAndGetCache(IEnumerable<WeatherForecast> listWeatherForecast, int inTimeInMinutes)
        {
            // Set cache options
            var oCacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(inTimeInMinutes));

            // Set object in cache
            _memoryCache.Set(sWeatherForecastKey, listWeatherForecast, oCacheOptions);
            return listWeatherForecast;
        }

        /// <summary>
        /// Calculate/Fetch the weather information form business functions
        /// </summary>
        /// <returns></returns>
        private static List<WeatherForecast> GetWeatherForecast()
        {
            var oRandom = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = oRandom.Next(-20, 55),
                Summary = Summaries[oRandom.Next(Summaries.Length)]
            })
            .ToList();
        }
    }
}
