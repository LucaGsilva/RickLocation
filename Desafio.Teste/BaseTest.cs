using Microsoft.EntityFrameworkCore;

namespace Desafio.Teste
{
    public class BaseTest
    {
        protected DbContext context;
        protected BaseTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("teste");
            context = new DesafioContext(optionsBuilder.Options);
        }
    }
}
