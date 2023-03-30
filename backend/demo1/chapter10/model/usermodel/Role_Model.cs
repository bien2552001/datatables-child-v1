using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;

namespace demo1.chapter10.model.usermodel
{
    [CollectionName("Roles")]
    public class Role_Model : MongoIdentityRole<Guid>
    {
        public string Role { get; set; }

    }
}
