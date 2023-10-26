using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.General
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }

        public bool Succeeded { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
        public T Data { get; set; }
    }
}
