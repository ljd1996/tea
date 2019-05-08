using System;
using System.ComponentModel.DataAnnotations;

namespace tea.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }   
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string role { get; set; }
    }
}
