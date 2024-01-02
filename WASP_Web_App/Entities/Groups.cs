using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WASP_Web_App.Entities
{
    public class Groups
    {
        [Required, Key]
        public int Group_ID { get; set; }

        [Required, StringLength(50)]
        public required string Name { get; set; }


        public ICollection<GroupKeys>? GroupKeys { get; } = new List<GroupKeys>();
        public ICollection<Permissions>? Permissions { get; } = new List<Permissions>();
    }
}
