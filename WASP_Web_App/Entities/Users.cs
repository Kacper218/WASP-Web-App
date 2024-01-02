using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WASP_Web_App.Entities
{
    public class Users
    {
        [Required, Key]
        public required int User_ID { get; set; }

        [Required, StringLength(50)]
        public required string Name { get; set;}

        [Required, StringLength(50)]
        public required string Surname { get; set;}

        [ForeignKey("User_ID")]
        public Auth? Auth { get; set; }
    }
}
