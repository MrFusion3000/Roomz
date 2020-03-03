using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roomz.Data
{
    public class Booker
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }

        public int BookerRoleId { get; set; }

        [ForeignKey("BookerRoleId")]
        public virtual BookerRole BookerRole { get; set; }

    }
}
