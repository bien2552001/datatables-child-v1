using System;

namespace demo1.entities.model
{
    public class datamodel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public double value { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
