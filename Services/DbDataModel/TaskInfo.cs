using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DbDataModel
{
    [Table("TBL_TASK_DTLS")]
    public class TaskInfo
    {
        public string getSequenser()
        {
            return "SEQ_TBL_TASK";
        }

        [Key]
        public decimal TASK_ID { get; set; }

        public string TASK_TITLE { get; set; }

        public string TASK_DESC { get; set; }

        public DateTime DUE_DATE { get; set; }

        public decimal STATUS { get; set; }

        public decimal? CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }

        public decimal? MODIFIED_BY { get; set; }


        public DateTime? MODIFIED_DATE { get; set; }


    }
}
