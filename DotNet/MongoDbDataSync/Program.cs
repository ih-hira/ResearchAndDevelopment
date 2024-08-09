using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDbDataSync;

Console.WriteLine("Service started at: " + DateTime.Now.ToString());

var serviceProvider = new ServiceCollection()
            .AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"))
            .AddSingleton<IMongoDatabase>(provider =>
            {
                var client = provider.GetService<IMongoClient>();
                return client.GetDatabase("leaked-db");
            })
            .AddScoped<IUserRepository, UserRepository>()
            .BuildServiceProvider();

// Resolve the repository
var userRepository = serviceProvider.GetService<IUserRepository>();

//var config = new MapperConfiguration(cfg =>
//{
//    cfg.CreateMap<UserInfo, UserInfoV2>().ForMember(dest => dest.Name, opt => opt.Ignore());
//});

//IMapper mapper = config.CreateMapper();

var dataEntry = new DataEntry(userRepository);

var filepath = "E:\\Kali_Backup\\leaked-data\\user_list\\New folder\\data_list_9.csv";
var extension = "csv";
dataEntry.EntryDataV2(filepath, extension);
//dataEntry.UpdateData();

Console.WriteLine("Service ended at: " + DateTime.Now.ToString());
Console.ReadLine();