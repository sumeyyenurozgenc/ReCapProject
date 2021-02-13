using ReCap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCap.Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }

    }
}
