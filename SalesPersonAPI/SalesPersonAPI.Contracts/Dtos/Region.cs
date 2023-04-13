namespace SalesPersonAPI.Contracts.Dtos
{
    public class Region
    {
        public int CityId { get; set; }
        public string? City { get; set; }
        public int StateId { get; set; }
        public string? State { get; set; }
        public bool IsPrimary { get; set; }
    }
}
