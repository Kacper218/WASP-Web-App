using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WASP_Web_App.Entities
{
    public class Auth
    {
        [Key, Required]
        public required int User_ID { get; set; }

        [Required, StringLength(50)]
        public required string Login { get; set; }

        [Required]
        public required string Password { get; set; }


        public virtual Users? Users { get; set; }
        public ICollection<Permissions>? Permissions { get; } = new List<Permissions>();
        public ICollection<SpecialPermissions>? SpecialPermissions { get; } = new List<SpecialPermissions>();
        public ICollection<Rent>? Rent { get; } = new List<Rent>();


        //+RFID
    }
}
