namespace Domain.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public ProductParameters() { } 
            //=> OrderBy = "";
        public uint MinPrice { get; set; } 
        public uint MaxPrice { get; set; } = int.MaxValue; 
        public bool ValidPriceRange => MaxPrice > MinPrice;
        public string? SearchTerm { get; set; }
    }
}
