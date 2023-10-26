using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Activity.Data
{
    public class ActivityData
    {

        public decimal activityId { get; set; }

        public string activityName { get; set; }

        public string activityDesc { get; set; }

        public decimal status { get; set; }

        public DateTime dueDate { get; set; }
    }
}
