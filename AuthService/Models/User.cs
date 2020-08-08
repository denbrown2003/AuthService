using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Models
{
    class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public int PasswordSalt { get; set; }


    }
}
