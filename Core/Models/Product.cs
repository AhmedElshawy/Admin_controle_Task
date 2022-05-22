using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Product()
        {
            ProductPropValues = new HashSet<ProductPropValues>();
        }

        public virtual ICollection<ProductPropValues> ProductPropValues { get; set; }
    }
}
