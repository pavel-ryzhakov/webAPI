namespace Domain.Exceptions
{
    public sealed class ProductNotFoundException : NotFoundException 
    { 
        public ProductNotFoundException(int productId) : base($"Товар с ID: {productId} отсутствует в базе данных.") 
        { 
        } 
    }
}
