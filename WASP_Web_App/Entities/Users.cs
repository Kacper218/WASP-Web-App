using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WASP_Web_App.Entities
{
    public class Users
    {
        [Required, Key]
        public int User_ID { get; set; }

        [Required, StringLength(50)]
        public required string Name { get; set;}

        [Required, StringLength(50)]
        public required string Surname { get; set;}

        public Auth? Auth { get; set; }
        public ICollection<Permissions>? Permissions { get; } = new List<Permissions>();
        public ICollection<SpecialPermissions>? SpecialPermissions { get; } = new List<SpecialPermissions>();
        public ICollection<Rent>? Rent { get; } = new List<Rent>();
    }
}
