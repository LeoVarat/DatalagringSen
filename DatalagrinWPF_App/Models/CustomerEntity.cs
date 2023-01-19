using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalagrinWPF_App.Models
{
    [Index(nameof(Email), IsUnique = true)]
    internal class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength (40)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(40)]
        public string LastName { get; set; } = null!;

        [Required, StringLength(100), Unicode(false)]
        public string Email { get; set; } = null!;

        [Required, StringLength(20)]
        public string Phone { get; set; } = null!;

        [Required]
        public int AdressId { get; set; }

        public virtual AdressEntity Adress { get; set; } = null!;
    }
}
