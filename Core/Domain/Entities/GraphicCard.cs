namespace Domain.Entities
{
    public class GraphicCard
    {
        public int Id { get; set; }
        public string Manufacture { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string GpuName { get; set; } = string.Empty;
        public string Vram { get; set; } = string.Empty;
        public string VramType { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public int Power { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } = string.Empty;

    }
}
