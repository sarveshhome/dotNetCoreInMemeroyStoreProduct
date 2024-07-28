using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace API.Model
{
    public class Product
    {
        public String? ID { get; set; }
        public String? Name { get; set; }
        public String? Brand { get; set; }
        public Product()
        {
            ID = Guid.NewGuid().ToString(); // Assign a GUID as the default ID
        }
    }

}
