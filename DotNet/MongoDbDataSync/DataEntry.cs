using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Reflection;

namespace MongoDbDataSync
{
    public class DataEntry
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DataEntry(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            //_mapper = mapper;
        }
        public void EntryData(string filePath, string fileExtension)
        {
            List<UserInfo> users;
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<UserInfoMap>();
                users = csv.GetRecords<UserInfo>().ToList();
            }
            foreach (var user in users)
            {
                user.CreatedOn = DateTime.Now;
                _userRepository.AddUser(user);
            }

        }
        public void EntryDataV2(string filePath, string fileExtension)
        {
            List<UserInfo> users;
            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter= "|"
            };
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var user = new UserInfo();
                        user.DemographicInfo = new DemographicInfo();
                        user.ParentsInfo = new ParentsInfo();
                        user.Name = new Name();
                        user.PersonalInfo = new PersonalInfo();
                        user.Password = new Password();
                        user.ContactInfo = new ContactInfo();
                        var citz = csv.GetField<string>("Citizenship")?.ToLower();
                        if (string.IsNullOrEmpty(citz))
                        {
                            citz = csv.GetField<string>("CitizenshipId")?.ToLower();
                        }
                        if (!string.IsNullOrEmpty(citz))
                        {
                            user.DemographicInfo.Citizenship = citz;
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("dob")))
                        {
                            user.DOB = csv.GetField<string>("dob");
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("Email")))
                        {
                            user.ContactInfo.Email = csv.GetField<string>("Email").ToLower();
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("FatherName")))
                        {
                            user.ParentsInfo.FatherName = csv.GetField<string>("FatherName").ToLower();
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("fname")))
                        {
                            user.Name.FirstName = csv.GetField<string>("fname").ToLower();
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("Mname")))
                        {
                            user.Name.MiddleName = csv.GetField<string>("Mname").ToLower();
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("NamePC")))
                        {
                            user.Name.Fullname = csv.GetField<string>("NamePC").ToLower();
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("Gender")))
                        {
                            user.PersonalInfo.Gender = csv.GetField<string>("Gender").ToLower();
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("pass")))
                        {
                            user.Password.Encrypted = csv.GetField<string>("pass");
                        }
                        if (!string.IsNullOrEmpty(csv.GetField<string>("Ph1")))
                        {
                            user.ContactInfo.PrimaryContactNo = csv.GetField<string>("Ph1");
                        }
                        //user.Name = new Name();
                        //user.Name.Fullname = csv.GetField<string>("Name")?.ToLower() ??null;
                        //user.Email = csv.GetField<string>("Email")?.ToLower() ?? null;
                        //user.PrimaryContactNo = csv.GetField<string>("Mobile")?.ToLower() ?? null;
                        //user.ParentsInfo = new ParentsInfo();
                        //user.ParentsInfo.FatherName = csv.GetField<string>("father name")?.ToLower();
                        //user.ParentsInfo.MotherName = csv.GetField<string>("mothername")?.ToLower();
                        //user.ParentsInfo.MotherNID = csv.GetField<string>("mothernid")?.TrimStart('0');
                        //user.ParentsInfo.FatherNID = csv.GetField<string>("guardiannid")?.TrimStart('0');



                        //user.OtherContactNo = new List<Field>();
                        //if (!string.IsNullOrEmpty(csv.GetField<string>("gamobile")))
                        //{
                        //    user.OtherContactNo.Add(new Field
                        //    {
                        //        Key = "Guardian_1",
                        //        Value = csv.GetField<string>("gamobile")
                        //    });
                        //}
                        //if (!string.IsNullOrEmpty(csv.GetField<string>("gmobile")))
                        //{
                        //    user.OtherContactNo.Add(new Field
                        //    {
                        //        Key = "Guardian_2",
                        //        Value = csv.GetField<string>("gmobile")
                        //    });
                        //}


                        //user.AcademicInfo = new AcademicInfo();
                        //if (!string.IsNullOrEmpty(csv.GetField<string>("gpa")))
                        //    user.AcademicInfo.SSC = csv.GetField<string>("gpa");
                        //if (!string.IsNullOrEmpty(csv.GetField<string>("yearpass")))
                        //    user.AcademicInfo.PassingYearSSC = csv.GetField<string>("yearpass");

                        //user.PersonalInfo = new PersonalInfo();
                        //if (!string.IsNullOrEmpty(csv.GetField<string>("studentnid")))
                        //    user.PersonalInfo.NID = csv.GetField<string>("studentnid").TrimStart('0');

                        //user.Name = new Name();
                        //if (!string.IsNullOrEmpty(csv.GetField<string>("studentname")))
                        //    user.Name.Fullname = csv.GetField<string>("studentname").ToLower();

                        //user.Source = csv.GetField<string>("website");
                        //user.Address = new Address();
                        //user.Address.Country = csv.GetField<string>("Country")?.ToLower()??null;
                        //user.Address.HomeAddress = csv.GetField<string>("Address")?.ToLower() ?? null;
                        //user.Address.City= csv.GetField<string>("City")?.ToLower() ?? null;

                        //user.SocialActivity= new SocialActivity();
                        //user.SocialActivity.Platforms= csv.GetField<string>("Social Activity")?.ToLower() ?? null;
                        user.CreatedOn = DateTime.Now;
                        _userRepository.AddUser(user);
                    }
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
            }
            


        }

        //public void UpdateData()
        //{
        //    var allUsers = _userRepository.GetAllUsers();
        //    foreach (var user in allUsers)
        //    {
        //        if (!string.IsNullOrEmpty(user.Email))
        //            user.Email = user.Email.ToLower();
        //        _userRepository.UpdateUser(user);
        //    }
        //}

    }
    public sealed class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            //Map(m => m.Name).Name("Name");
            //Map(m => m.Email).Name("email");
            //Map(m => m.Mobile).Name("Mobile");
            //Map(m => m.DOB).Name("dob");
            //Map(m => m.BloodGroup).Name("blood");
            //Map(m => m.FatherName).Name("father name");
            //Map(m => m.MotherName).Name("mother");
            //Map(m => m.Username).Name("user_login");
            //Map(m => m.Password.Encrypted).Name("pass");
            //Map(m => m.Password.Plaintext).Name("PlainText");
            //Map(m => m.Password.HashType).Name("hashtype");
            //Map(m => m.Source).Name("website");
            //Map(m => m.Country).Name("Country");
            //Map(m => m.Address.HomeAddress).Name("address");
        }
    }
}
