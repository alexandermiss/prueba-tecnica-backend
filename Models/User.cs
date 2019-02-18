using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(150)]
        [Required]
        public string Email { get; set; }


    }
}
