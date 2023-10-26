using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.General
{
    public class GeneralResponse
    {

        public string responseMsg { get; set; }=string.Empty;
        public bool isSucceeded { get; set; }=false;
    }
}
