using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_CRUD.Models.DTO
{
    public class CategoryToDisplayDTO
    {
        public short CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductToDisplayDTO> ProductToDisplayDTOs { get; set; }
    }
}
