using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Dtos.Request
{
    public class CategoryRequest
    {
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? State { get; set; }
    }
}
