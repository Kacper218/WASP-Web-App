using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace WASP_Web_App.Entities
{
    public class Keys
    {
        [Required, Key]
        public int Key_ID { get; set; }

        [Required, StringLength(50)]
        public required string Room { get; set; }

        //+QR

        public ICollection<GroupKeys>? GroupKeys { get; } = new List<GroupKeys>();
        public ICollection<SpecialPermissions>? SpecialPermissions { get; } = new List<SpecialPermissions>();
        public ICollection<Rent>? Rent { get; } = new List<Rent>();
    }
}
