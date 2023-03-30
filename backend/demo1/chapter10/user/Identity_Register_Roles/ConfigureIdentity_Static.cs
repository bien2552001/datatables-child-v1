using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using demo1.chapter10.model.usermodel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace demo1.chapter10.user.Identity_Register_Roles
{
    public static class ConfigureIdentity_Static
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var mongoIdentityConfigure = new MongoDbIdentityConfiguration
            {
                MongoDbSettings = new MongoDbSettings
                {
                    ConnectionString = "mongodb://localhost:27017",

                    DatabaseName = "User"
                },

                IdentityOptionsAction = options =>
                {

                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 10;
                    options.User.RequireUniqueEmail = true;


                    // lockout 
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    options.Lockout.MaxFailedAccessAttempts = 5;

                }
            };

            services.ConfigureMongoDbIdentity<User_Model, Role_Model, Guid>(mongoIdentityConfigure)
                .AddUserManager<UserManager<User_Model>>()
                .AddSignInManager<SignInManager<User_Model>>()
                .AddRoleManager<RoleManager<Role_Model>>()
                .AddDefaultTokenProviders();

        }
    }
}
