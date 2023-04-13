namespace SalesPersonAPI.Domain.Entities
{
    public class SalesPersonRegionXref
    {
        public int Id { get; set; }
        public int SalesPersonId { get; set; }
        public int CityId { get; set; }
        public String City { get; set; }
        public int StateId { get; set; }
        public String State { get; set; }
        public bool IsPrimary { get; set; }
        public int CreateByUserId { get; set; }
        public string? CreateByUser { get; set; }
        public int UpdateByUserId { get; set; }
        public string? UpdateByUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
