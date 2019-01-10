using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFagain
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public virtual List <Product> Products { get; set; }
        public Address Address { get; set; }
    }
}
