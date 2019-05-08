using System;
using System.ComponentModel.DataAnnotations;

namespace tea.Models
{
    public class Cart
    {
        [Key]
        public int id { get; set; }   
        public int count { get; set; }
        public int buy_id { get; set; }
        public int pro_id { get; set; }
    }
}
