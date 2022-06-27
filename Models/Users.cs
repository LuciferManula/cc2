namespace CC2.Models;
using System.ComponentModel.DataAnnotations;

    public class Users
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
    }