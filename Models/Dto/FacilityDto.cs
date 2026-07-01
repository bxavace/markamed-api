namespace markamed_api.Models.Dto
{
    public class FacilityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FacilityMajorType { get; set; }
        public string FacilityType { get; set; }
        public string? OwnershipMajorClassification { get; set; }
        public string? OwnershipSubClassification { get; set; }
        public string? StreetName { get; set; }
        public string? BuildingName { get; set; }
        public string? Region { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? Barangay { get; set; }
        public string? ZipCode { get; set; }
        public string? LandlineNumber { get; set; }
        public string? LandlineNumber2 { get; set; }
        public string? FaxNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? AlternateEmailAddress { get; set; }
        public string? Website { get; set; }
        public string? ServiceCapability { get; set; }
        public int? BedCapacity { get; set; }
        public string? LicenseStatus { get; set; }
        public string? LicenseNumber { get; set; }
        public string? LicenseDateIssued { get; set; }
    }
}