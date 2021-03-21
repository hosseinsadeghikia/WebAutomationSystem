using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAutomationSystem.ApplicationCore.Entities.Users
{
    public class ApplicationUsers : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalCode { get; set; }

        public string NationalCode { get; set; }

        public string Address { get; set; }

        public string BirthDate { get; set; }

        public byte Gender { get; set; }

        public string ImageUrl { get; set; }

        public string SignatureUrl { get; set; }

        public byte IsActive { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
