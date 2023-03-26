using System;

namespace demo1.entities.DTO
{
    public class PostDto
    {
        public double value { get; set; }
        public string Name = "Dòng điện";
        public DateTimeOffset Date = DateTimeOffset.Now;
    }
}
