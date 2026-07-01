namespace markamed_api.QueryParameters
{
    public class FacilityQueryParameters : BaseQueryParameters
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? FacilityType { get; set; }
        public string? FacilityMajorType { get; set; }
        public string? Barangay { get; set; }
        public string? Region { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public int? MinBedCapacity { get; set; }
        public int? MaxBedCapacity { get; set; }
        public string? LicenseStatus { get; set; }
        public bool? HasLicense { get; set; }
    }
}