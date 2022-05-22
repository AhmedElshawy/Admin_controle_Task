using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategotyName { get; set; }

        public int? ParentCategotyId { get; set; }

        public Category ParentCategory { get; set; }

        public CategoryProp CategoryProp { get; set; }

        public Category()
        {           
            Products = new HashSet<Product>();
        }   
        public virtual ICollection<Product> Products { get; set; }
    }
}
