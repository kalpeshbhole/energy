namespace SalesPersonAPI.Contracts.Dtos
{
    public class SalesPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Region>? Regions { get; set; }
        public int CreateByUserId { get; set; }
        public string? CreateByUser { get; set; }
        public int UpdateByUserId { get; set; }
        public string? UpdateByUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
