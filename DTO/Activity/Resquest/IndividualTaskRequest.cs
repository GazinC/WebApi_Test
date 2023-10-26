using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Activity.Resquest
{
    public class IndividualTaskRequest
    {
        [Required(ErrorMessage = "Task Id Required")]
        public decimal taskId {  get; set; }   
    }
}
