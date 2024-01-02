using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WASP_Web_App.Entities
{
    public class Auth
    {
        [Key, Required]
        public int User_ID { get; set; }

        [Required, StringLength(50)]
        public required string Login { get; set; }

        [Required, StringLength(50)]
        public required string Password { get; set; }


       // [ForeignKey("UserId")]
        public virtual  Users? Users { get; set; }


        //+RFID
    }
}
