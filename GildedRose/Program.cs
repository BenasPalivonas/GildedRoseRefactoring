using GildedRose.Services.ConsoleWriter;
using GildedRose.Services.GildedRose;
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
        private readonly IGildedRoseService _gildedRose;

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }
        public Program(IItems items, IConsoleWriter consoleWriter, IGildedRoseService gildedRose)
        {
            _items = items;
            _consoleWriter = consoleWriter;
            _gildedRose = gildedRose;
        }
        public void Run()
        {
            Console.WriteLine("OMGHAI!");
            IList<Item> Items = _items.GetItems();
            for (var i = 0; i < 31; i++)
            {
                _consoleWriter.WriteItemsToConsole(Items, i);
                _gildedRose.UpdateQuality(Items);
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
                    services.AddTransient<IGildedRoseService, GildedRoseService>();
                });
        }
    }
}

