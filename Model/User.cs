﻿using System.ComponentModel.DataAnnotations;

namespace demo.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
