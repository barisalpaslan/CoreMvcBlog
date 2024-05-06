using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        //public : erişim belirleyici türü
        //int : değişken türü

        [Key]
        public int ID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool? CategoryStatus { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
