using System;
using System.ComponentModel.DataAnnotations;

namespace tea.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int count { get; set; }
        public string image { get; set; }
        public int status { get; set; }
    }
}
