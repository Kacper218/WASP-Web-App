using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WASP_Web_App.Entities
{
    public class Permissions
    {
        [Required, HiddenInput, Key]
        public int Permission_ID { get; set; }

        [Required]
        public required int User_ID { get; set; }

        [Required]
        public required int Group_ID { get; set; }


       // [ForeignKey("User_ID")]
        public virtual Users? Users { get; set; }
       /// [ForeignKey("Group_ID")]
        public virtual Groups? Groups { get; set; }
    }
}
