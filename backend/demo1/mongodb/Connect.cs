using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System.Text.Json;

namespace demo1.mongodb
{
    public static class Connect
    {
        public static void ConfigureMongoDbClient(this IServiceCollection services, IConfiguration Configuration)

        {

            //Add service to the container
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String)); // Định dạng  ID thành chuỗi kiểu Guid ;; giúp cho Mongo có thể hiển thị dạng chuỗi Json được

            BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));// Định dạng DateoffTime thành chuỗi kiểu ;; giúp cho Mongo có thể hiển thị dạng chuỗi Json được

            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));// Định dạng DateoffTime thành chuỗi kiểu ;; giúp cho Mongo có thể hiển thị dạng chuỗi Json được




            //ConnectMongoClient
            services.AddSingleton<IMongoClient>(ServiceProvider =>
            {
                var connect = Configuration.GetSection(nameof(ModelConnect)).Get<ModelConnect>();

                return new MongoClient(connect.ConnectionString);

            });

        }
    }
}