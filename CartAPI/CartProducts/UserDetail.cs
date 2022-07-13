using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.CartProducts
{
    public partial class UserDetail
    {
        public int RegistrationId { get; set; }
        public string UserName { get; set; }
        public long? MobileNumber { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string ProfilePicture { get; set; }
        public string UserId { get; set; }
    }
}
