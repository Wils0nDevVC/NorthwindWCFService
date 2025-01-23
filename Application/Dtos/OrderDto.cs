using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Dtos
{
    [DataContract]
    public class OrderDto
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public DateTime ShippedDate { get; set; }
    }
}
