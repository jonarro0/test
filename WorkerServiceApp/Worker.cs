using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerServiceApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Context _context;

        public Worker(ILogger<Worker> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Insertar datos en la base de datos en la tabla Test
            _context.Tests.Add(new Model.Test
            {
                Name = "Juan",
                Age = 20,
                Address = "Calle 1",
                Email = "asdasd"
            });

            await _context.SaveChangesAsync();

            // Consultar datos en la base de datos en la tabla Test
            var test = await _context.Tests.ToListAsync();

            foreach (var item in test)
            {
                _logger.LogInformation($"Name: {item.Name} Age: {item.Age} Address: {item.Address} Email: {item.Email}");
            }
        }
    }
}
