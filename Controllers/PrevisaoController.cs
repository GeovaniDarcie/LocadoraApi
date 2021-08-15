using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Academia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrevisaoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PrevisaoController> _logger;

        public PrevisaoController(ILogger<PrevisaoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PrevisaoTempo> Get(int a)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new PrevisaoTempo
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
