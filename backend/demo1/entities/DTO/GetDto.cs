using System;

namespace demo1.entities.DTO
{
    public class GetDto
    {
        public Guid Id { get; set; }
        public string Name  { get; set; }
        public double value { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
