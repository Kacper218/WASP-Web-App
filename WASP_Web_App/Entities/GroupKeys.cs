using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WASP_Web_App.Entities
{
    public class GroupKeys
    {
        [Required, HiddenInput, Key]
        public int GroupKey_ID { get; set; }

        [Required]
        public required int Key_ID { get; set; }

        [Required]
        public required int Group_ID { get; set; }


        [ForeignKey("Key_ID")]
        public virtual Keys? Keys { get; set; }

        [ForeignKey("Group_ID")]
        public virtual Groups? Groups { get; set; }
    }
}
