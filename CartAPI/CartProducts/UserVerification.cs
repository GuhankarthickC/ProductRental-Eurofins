using System;
using System.Collections.Generic;

#nullable disable

namespace CartAPI.CartProducts
{
    public partial class UserVerification
    {
        public string UserId { get; set; }
        public string UserSelfie { get; set; }
        public string UserKycProof { get; set; }
        public string KycStatus { get; set; }
        public string KycDocumentType { get; set; }
    }
}
