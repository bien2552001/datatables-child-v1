using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using demo1.entities.model;
using MongoDB.Bson;
using demo1.Interface;
using demo1.entities.DTO;

namespace demo1.repository.data
{
    public class datarepository: Idatarepository
    {
        private const string databaseName = "Data";   // Thuộc tính tên cơ sở dữ liệu 

        private const string collectionName = "datatest"; // Thuộc tính tên của bộ sưu tập 

        //private readonly FilterDefinitionBuilder<datamodel> filterBuilder = Builders<datamodel>.Filter; // Thuộc tính bộ lọc 

        private readonly IMongoCollection<datamodel> currentCollection; // Tạo bộ sưu tập từ lớp Item

        public datarepository()
        {
        }

        public datarepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName); // Tham chiếu đến tên cơ sở dữ liệu 

            currentCollection = database.GetCollection<datamodel>(collectionName);// Tham chiếu đến tên bộ sưu tập 

        }
        public async Task<IEnumerable<datamodel>> GetAllCurrentAsync(DateTimeOffset? startDate , DateTimeOffset? endDate)
        {
            var filter = Builders<datamodel>.Filter.Empty;

            if (startDate != null)
            {
                filter = Builders<datamodel>.Filter.And(filter, Builders<datamodel>.Filter.Gte(x => x.Date, startDate));
            }

            if (endDate != null)
            {
                filter = Builders<datamodel>.Filter.And(filter, Builders<datamodel>.Filter.Lte(x => x.Date, endDate));
            }

            return await currentCollection.Find(filter).ToListAsync();
        }

        public async Task Post(datamodel data)
        {
            await currentCollection.InsertOneAsync(data);
        }


        //public async Task<datamodel> GetCurrentAsync(Guid id)
        //{
        //    var filter = filterBuilder.Eq(item => item.Id, id); // Id phải khớp với Id nhận được từ tham số 
        //    return await currentCollection.Find(filter).SingleOrDefaultAsync(); // Phương thức SingleorDefult chỉ cho phép trả về 1 dữ liệu bất kì tìm thấy 
        //}






        //public async Task DeleteCurrentAsync(Guid id)
        //{
        //    var filter = filterBuilder.Eq(item => item.Id, id); // Lọc theo Id
        //    await currentCollection.DeleteOneAsync(filter); // Mỗi lần thực thi sẽ xóa theo id truyền vào 
        //}



        //public async Task UpdateCurrentAsync(datamodel data)
        //{
        //    var filter = filterBuilder.Eq(exsitingItem => exsitingItem.Id, data.Id); // Lọc theo id 
        //    await currentCollection.ReplaceOneAsync(filter, data);
        //}
    }
}
