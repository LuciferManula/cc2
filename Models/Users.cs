namespace CC2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

    public class Users
    {
        [Key]
        public int? Id { get; set; }
        public string? UserName { get; set; }
    }