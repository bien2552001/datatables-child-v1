using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

namespace demo1.chapter10.model.usermodel
{
    [CollectionName("User")]
    public class User_Model : MongoIdentityUser<Guid>
    {
        public string Fullname { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}
