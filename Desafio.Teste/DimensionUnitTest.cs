using Desafio.Service;
using Desafio.Service.Exceptions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Desafio.Teste
{
    class DimensionUnitTest : BaseTest
    {
        private RickService rickService;
        public DimensionUnitTest() : base()
        {
            rickService = new RickService(this.context);
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ValidateNameEmpty()
        {

            Assert.ThrowsAsync<System.ArgumentException>(async () => { await rickService.CreateDimension(""); });
            Assert.ThrowsAsync<System.ArgumentException>(async () => { await rickService.CreateDimension(null); });
        }

        [Test]
        public async Task ValidateNameUpperCaseDimension()
        {

            var dimension = await rickService.CreateDimension("abc");
            Assert.AreEqual("ABC", dimension.Name);

        }

        [Test]
        public async Task ValidateDuplicateDimension()
        {
            await rickService.CreateDimension("A-52");
            Assert.ThrowsAsync<RickLocationException>(async () => { await rickService.CreateDimension("A-52"); });
        }

        [Test]
        public async Task ValidateTrimNameDimensionAsync()
        {
            var dimension = await rickService.CreateDimension(" abc ");

            Assert.AreEqual("abc", dimension.Name.ToLower());

            Assert.ThrowsAsync<System.ArgumentException>(async () => { await rickService.CreateDimension(" "); });
        }

        [Test]
        public async Task ValidateInsertDimension()
        {
            var dimesnsion = await rickService.CreateDimension("D-328");
            Assert.AreNotEqual(0, dimesnsion.Id);
            Assert.AreEqual("D-328", dimesnsion.Name);
        }


    }
}
