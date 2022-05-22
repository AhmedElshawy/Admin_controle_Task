using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CategoryProp
    {
        public int Id { get; set; }
        public bool Length { get; set; }
        public bool Height { get; set; }
        public bool ScreenReslution { get; set; }
        public bool BrandName { get; set; }
        public bool Color { get; set; }
        public bool SkinType { get; set; }
        public bool Volume { get; set; }
        public bool Weight { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
