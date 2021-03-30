using Desafio.Models.Models;
using Desafio.Service;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Desafio.Teste
{
    class TarvelUnitTest : BaseTest
    {
        private readonly TravelService travelService;
        private readonly RickService rickService;
        private Rick rick;

        public TarvelUnitTest() : base()
        {
            travelService = new TravelService(this.context);
            rickService = new RickService(this.context);

        }

        [SetUp]
        public async Task SetupAsync()
        {
           this.rick = await this.rickService.Create("Pastel-47");
        }


        [Test]
        public void ValidateDimensionExists()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => { await travelService.Create(0, 0); });
        }

        [Test]
        public void ValidateRickExists()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => { await travelService.Create(0, 0); });
        }

        [Test]
        public async Task ValidateInsertTarvel()
        {
            try
            {
                var travel = await travelService.Create(rick.Id, rick.DimensionId);
                Assert.IsNotNull(travel);
                Assert.AreNotEqual(0, travel.Id);
            }
            catch (Exception)
            {

                Assert.Fail();
            }

        }

    }
}
