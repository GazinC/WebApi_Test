using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Activity.Resquest
{
    public class NewActivityRequest
    {
        
        public decimal activityId { get; set; }
        [Required(ErrorMessage = "Status Required")]
        public decimal status { get; set; }
        [Required(ErrorMessage = "Task Name is required")]
        [StringLength(50,ErrorMessage ="Task name must be between 5 and 50",MinimumLength = 5)]
        public string activityName { get; set; }=string.Empty;

        [Required(ErrorMessage = "Task description is required")]
        [StringLength(500, ErrorMessage = "Task name must be between 10 and 500", MinimumLength = 10)]
        public string activityDesc { get; set; } = string.Empty;

        [Required(ErrorMessage = "Task due date is required")]
        public DateTime dueDate { get; set; }

        [Required]
        public long   createdBy { get; set; }   
       
    }
}
