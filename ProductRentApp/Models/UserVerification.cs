using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductRentApp.Models
{
    public class UserVerification
    {
        public string UserId { get; set; }
        public string UserSelfie { get; set; }
        public string UserKycProof { get; set; }
        public string KycStatus { get; set; }
        public string KycDocumentType { get; set; }
    }
}
