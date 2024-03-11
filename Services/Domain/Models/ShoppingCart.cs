using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Domain.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsCompleted { get; set; }
        public List<Item> items { get; set; }
    }
}
