using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProductPropValues
    {
        public int Id { get; set; }
        public int? Length { get; set; }
        public int? Height { get; set; }
        public int? ScreenReslution { get; set; }
        public string BrandName { get; set; }
        public string Color { get; set; }
        public string SkinType { get; set; }
        public int? Volume { get; set; }
        public int? Weight { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
