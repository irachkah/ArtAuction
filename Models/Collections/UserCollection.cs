using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtAuction.Models.Collections
{
    public class UserCollection : IUserCollection
    {
        private readonly IMongoCollection<User> _users;

        public List<User> Users
        {
            get
            {
                return _users.Find(user => true).ToList();
            }
        }

        public UserCollection(string conStr)
        {
            var client = new MongoClient(conStr);
            var database = client.GetDatabase("UsersDB");
            _users = database.GetCollection<User>("Users");
        }

        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void RemoveUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void UpdateUser(User user)
        {
            var filter = new BsonDocument("_id", new ObjectId(user.Id));
            var res = _users.ReplaceOne(filter, user);
        }

        public bool ValidationSucceeded(string email, string password)
        {
            var user =  _users.Find(us => us.Email == email && us.Password == password).ToList();
            return user.Count != 0;
        }

        public User FindUser(string email)
        {
            var user = _users.Find(us => us.Email == email).ToList();
            return user.Count == 0 ? null : user[0];
        }
    }
}
