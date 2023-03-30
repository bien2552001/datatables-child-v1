﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace demo1.chapter10.user.ConfigureJWT_Login
{
    public static class ConfigureJWT_Static
    {//Cấu hình JWT
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            var secretKey = Environment.GetEnvironmentVariable("SECRET");

            services.AddAuthentication(opt =>
            {
                // JWT 
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            })



            // Add JWT
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,

                    ValidAudience = jwtSettings.GetSection("validAudience").Value,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };
            });

        }
    }
}