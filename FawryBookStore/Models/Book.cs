using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryBookStore.Models
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public double price { get; set; }
        [ForeignKey("Type")]
        public int Type_Id { get; set; }
        public Type? Type { get; set; }
        public int? Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
