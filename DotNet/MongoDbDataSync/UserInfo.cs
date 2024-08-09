using MongoDB.Bson;

namespace MongoDbDataSync
{
    public class UserInfo
    {
        public ObjectId _id { get; set; }
        public Name Name { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public ParentsInfo ParentsInfo { get; set; }
        public HealthInfo HealthInfo { get; set; }
        public AcademicInfo AcademicInfo { get; set; }
        public SocialActivity SocialActivity { get; set; }
        public DemographicInfo DemographicInfo { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public string DOB { get; set; }
        public string Source { get; set; }
        public Password Password { get; set; }
        public Address Address { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class Password
    {
        public string Encrypted { get; set; }
        public string Plaintext { get; set; }
        public string HashType { get; set; }
    }
    public class Address
    {
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
    public class Field
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class ParentsInfo
    {
        public string FatherName { get; set; }
        public string FatherNID { get; set; }
        public string MotherName { get; set; }
        public string MotherNID { get; set; }
    }
    public class ContactInfo
    {
        public string PrimaryContactNo { get; set; }
        public string SecondaryContactNo { get; set; }
        public string Email { get; set; }
    }
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Fullname { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Username { get; set; }
    }
    public class HealthInfo
    {
        public string BloodGroup { get; set; }
    }
    public class AcademicInfo
    {
        public string SSC { get; set; }
        public string PassingYearSSC { get; set; }
    }
    public class PersonalInfo
    {
        public string NID { get; set; }
        public string Gender { get; set; }
    }
    public class DemographicInfo
    {
        public string Citizenship { get; set; }
    }
    public class SocialActivity
    {
        public string Platforms { get; set; }
        public List<Field> SocialAccounts { get; set; }
    }
}
