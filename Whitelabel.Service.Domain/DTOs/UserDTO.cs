using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Whitelabel.Service.Domain.DTOs
{
    [DataContract]
    public class UserDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string FirstName { get; set; }
    }
}
