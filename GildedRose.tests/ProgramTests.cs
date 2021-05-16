using csharpcore;
using GildedRose.Services.ConsoleWriter;
using GildedRose.Services.GildedRose;
using GildedRose.Services.ItemsService;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.tests
{
    public class ProgramTests
    {
        private readonly IItemsService _itemsService;
        private readonly IConsoleWriter _consoleWriter;
        private readonly IGildedRoseService _gildedRose;
        public ProgramTests()
        {
            var Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            };
            var itemsServiceMock = new Mock<IItemsService>();
            itemsServiceMock.Setup(i => i.GetItems()).Returns(Items);
            var consoleWriterMock = new Mock<IConsoleWriter>();
            var gildedRoseMock = new Mock<IGildedRoseService>();
            _itemsService = itemsServiceMock.Object;
            _consoleWriter = consoleWriterMock.Object;
            _gildedRose = gildedRoseMock.Object;
        }
        [Fact]
        public void Run()
        {

            try
            {
                var program = new Program(_itemsService, _consoleWriter, _gildedRose);
                program.Run();
                return;
            }

            catch
            {
                Assert.False(true);
            }

        }
    }
}
