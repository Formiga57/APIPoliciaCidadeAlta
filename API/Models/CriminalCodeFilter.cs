namespace API.Models
{
    public class CriminalCodeFilter
    {
        public int Page { get; set; }
        public int Rows { get; set; }
        public bool Way { get; set; }
        public uint OrderId { get; set; }
        public uint FilterId { get; set; }
        public string Filter { get; set; } = null!;
    }
}