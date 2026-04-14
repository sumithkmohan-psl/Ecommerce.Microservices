using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.DTOs
{
    public class PaginationDto
    {
        public int Index { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
