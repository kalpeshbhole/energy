namespace SalesPersonAPI.Domain.Models
{
    public class Region
    {
        public int CityId { get; set; }
        public string? City { get; set; }
        public int StateId { get; set; }
        public string? State { get; set; }
        public bool IsPrimary { get; set; }
        public int CreateByUserId { get; set; }
        public string? CreateByUser { get; set; }
        public int UpdateByUserId { get; set; }
        public string? UpdateByUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
