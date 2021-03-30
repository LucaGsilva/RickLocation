using Desafio.Service;
using Desafio.Service.Exceptions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Desafio.Teste
{
    public class RickUnitTest : BaseTest
    {

        private RickService rickService;
        private TravelService travelService;

        public RickUnitTest() : base()
        {
            rickService = new RickService(this.context);
            travelService = new TravelService(this.context);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task ValidateInsertRick()
        {

            try
            {
                var rick = await rickService.Create("Y-32");
                Assert.IsNotNull(rick);
                Assert.AreNotEqual(rick.Id, 0);
                Assert.AreEqual(rick.Dimension.Name, "Y-32");
            }
            catch (Exception)
            {

                Assert.Fail();
            }

        }

        [Test]
        public async Task ValidateDimensionExistsAsync()
        {
            await rickService.CreateDimension("C-152");
            Assert.ThrowsAsync<RickLocationException>(async () => { await rickService.Create("C-152"); });
        }


        [Test]
        public async Task ValidateRickNotExistsInDimenson()
        {

            await rickService.CreateDimension("F-465");
            Assert.ThrowsAsync<RickLocationException>(async () => { await rickService.Create("F-465"); });

        }

        [Test]
        public async Task ValidateRickTravels()
        {
            // Criar o Rick
            var rick = await rickService.Create("W-584");

            //Cria as Dimensões para Viajar

            var qy58 = await rickService.CreateDimension("QY-58");
            var qy589 = await rickService.CreateDimension("QY-589");

            // Registra as Viagens
            await travelService.Create(rick.Id, qy58.Id);
            await travelService.Create(rick.Id, qy589.Id);

            rick = await rickService.GetRick(rick.Id);

            Assert.IsNotNull(rick.Travels);
            Assert.AreEqual(2,rick.Travels.Count);
            Assert.AreEqual ("QY-58", rick.Travels[0].Dimension.Name);
            Assert.AreEqual ("QY-589", rick.Travels[1].Dimension.Name);

        }


    }
}