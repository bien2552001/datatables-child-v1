using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using demo1.entities.model;
using demo1.repository.data;
using demo1.Interface;
using demo1.entities.DTO;
using demo1.entities;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo1.Controllers
{
    [ApiController]
    [Route("api")]
    public class DataController : ControllerBase
    {
        private readonly Idatarepository _getmongo;
        private readonly IMapper _map;
       public DataController(Idatarepository getmongo, IMapper map) { 

        _getmongo= getmongo;
            _map= map;
        }

        [HttpGet]
        //public async Task<IEnumerable<datamodel>> GetAllCurrentAsync(DateTime startDate, DateTime endDate)
        public async Task<IEnumerable<datamodel>> GetAllCurrentAsync([FromQuery] DateTimeOffset? startDate, [FromQuery] DateTimeOffset? endDate)
        {

            var users = await _getmongo.GetAllCurrentAsync(startDate, endDate);

            return users;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDto item)
        {

            var itemCreateDto = _map.Map<datamodel>(item); // chúng tôi ánh xạ Item để tạo thành thực thể itemCreateDto

            await _getmongo.Post(itemCreateDto); // gọi phương thức kho lưu trữ để tạo itemCreateDto mới trong cơ sở dữ liệu 

            var itemToReturn = _map.Map<GetDto>(itemCreateDto); //  chúng tôi ánh xạ thực thể Item cho đối tượng ItemDto để trả lại cho khách hàng.


            return CreatedAtAction(nameof(GetAllCurrentAsync), new { id = itemToReturn.Id }, itemToReturn);// THam khảo phương thức CreateAtAction tại: https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core
                                                                                                           // Khi chạy bất đồng bộ thì phương thức CreatedAtAction(nameof(GetItemAsync) sẽ xóa đi hậu tố Async và để khắc phục điều đó thì trong lớp startup cấu hình lại phương thức addController
        }









    }
}
