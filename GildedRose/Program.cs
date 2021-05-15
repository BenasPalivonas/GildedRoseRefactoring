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

    
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }
        public Program(IItems items)
        {
            _items = items;
        }
        public void Run()
        {
            Console.WriteLine("working");
       /* IList<Item> Items = _items.GetItems()
            //var app = new GildedRose(Items);
            for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < Items.Count; j++)
            {
                System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
            }
            Console.WriteLine("");
            //app.UpdateQuality();
       */
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IItems, Items>();
                });
        }
    }
}

