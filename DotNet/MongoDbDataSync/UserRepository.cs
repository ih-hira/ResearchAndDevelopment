using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDbDataSync
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserInfo> _userCollection;
        public UserRepository(IMongoDatabase database)
        {
            _userCollection = database.GetCollection<UserInfo>("users-info");
        }
        public void AddUser(UserInfo user)
        {
            _userCollection.InsertOne(user);
        }

        public void DeleteUser(UserInfo user)
        {
            var filter = Builders<UserInfo>.Filter.Eq("_id", user._id); 
            var deleteResult = _userCollection.DeleteMany(filter);
        }
        public void UpdateUser(UserInfo user)
        {
            var filter = Builders<UserInfo>.Filter.Eq("_id", user._id);
            _userCollection.ReplaceOne(filter,user);
        }
        public List<UserInfo> GetAllUsers()
        {
            var filter = Builders<UserInfo>.Filter.Empty;
            return _userCollection.Find(filter).ToList();
        }
     
    }
}
