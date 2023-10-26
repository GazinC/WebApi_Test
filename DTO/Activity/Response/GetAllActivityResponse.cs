using DTO.Activity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Activity.Response
{
    public class GetAllActivityResponse
    {
        public GetAllActivityResponse()
        {

            activityDatas = new List<ActivityData>();
        }


        public bool isDataAvailable { get; set; } = false;
        public string responseMsg { get; set; }=string.Empty;
        public List<ActivityData> activityDatas { get; set; }
    }

}
