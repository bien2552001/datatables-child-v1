using AutoMapper;
using demo1.chapter10.model.userDto;
using demo1.chapter10.model.usermodel;
using demo1.entities.DTO;
using demo1.entities.model;

namespace demo1.entities
{
    public class Mapping: Profile
    {
        public Mapping() 
        {
            CreateMap<PostDto, datamodel>();//Ánh xạ thuộc tính từ lớp Item đến lớp ItemDto

            CreateMap<datamodel, GetDto>();//Ánh xạ thuộc tính từ lớp Item đến lớp ItemDto




            //________________________________________USER_____________________________________________________

            CreateMap<RoleRequestDto, Role_Model>();


            CreateMap<RegisterRequestDto, User_Model>();


            CreateMap<User_Model, RegisterRequestDto>();










        }
    }
}
