using GildedRose.Services.ConsoleWriter;
using GildedRose.Services.Items;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        private readonly IItems _items;
        private readonly IConsoleWriter _consoleWriter;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }
        public Program(IItems items, IConsoleWriter consoleWriter)
        {
            _items = items;
            _consoleWriter = consoleWriter;
        }
        public void Run()
        {
            Console.WriteLine("OMGHAI!");
            IList<Item> Items = _items.GetItems();
            var app = new GildedRose(Items);
            for (var i = 0; i < 31; i++)
            {
                _consoleWriter.WriteItemsToConsole(Items, i);
                app.UpdateQuality();
            }
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IItems, Items>();
                    services.AddTransient<IConsoleWriter, ConsoleWriter>();
                });
        }
    }
}

