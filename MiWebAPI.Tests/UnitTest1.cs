using Xunit;

namespace MiWebAPI.Tests
{
    public class ProductoTests
    {
        [Fact]
        public void TestDeCarga_DeberiaPasar()
        {
            var producto = new Producto(1, "Test", 100);
            Assert.Equal(100, producto.Precio);
        }
    }
}