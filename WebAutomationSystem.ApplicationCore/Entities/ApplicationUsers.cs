using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutomationSystem.ApplicationCore.Entities
{
    public class ApplicationUsers : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(256)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string PersonalCode { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string NationalCode { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string BirthDate { get; set; }

        public byte Gender { get; set; }
        public string ImageUrl { get; set; }
        public string SignatureUrl { get; set; }
        public byte IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
