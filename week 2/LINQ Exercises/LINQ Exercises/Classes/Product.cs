using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Exercises.Classes
{
    class Product
    {
        [RegularExpression(@"[A-Z]{2}[0-9]{3}-[0-9]{4}$",
            ErrorMessage = "Not allowed article")]
        public string ArticleNumber { get; set; }
        public string Category { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
