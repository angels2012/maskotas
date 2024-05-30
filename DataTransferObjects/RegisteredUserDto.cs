using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maskotas.DataTransferObjects
{
    public class RegisteredUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}