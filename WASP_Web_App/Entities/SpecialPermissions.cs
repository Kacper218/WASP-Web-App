using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WASP_Web_App.Entities
{
    public class SpecialPermissions
    {
        [Required, HiddenInput, Key]
        public int SpecialPermission_ID { get; set; }

        [Required]
        public required int User_ID { get; set; }

        [Required]
        public required int Key_ID { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }


        [ForeignKey("User_ID")]
        public virtual Auth? Auth { get; set; }
     //   [ForeignKey("Key_ID")]
        public virtual Keys? Keys { get; set; }
    }
}
