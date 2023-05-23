using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Dtos.Response
{
    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public DateTime AuditCreatedDate { get; set; }
        public int State { get; set; }
        public string? StateCategory { get; set; }

    }
}
