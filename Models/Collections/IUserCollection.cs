using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtAuction.Models.Collections
{
    public interface IUserCollection
    {
        List<User> Users { get; }
        User AddUser(User item);
        void RemoveUser(string id);
        void UpdateUser(User user);
        bool ValidationSucceeded(string a, string b);
        User FindUser(string id);
    }
}
