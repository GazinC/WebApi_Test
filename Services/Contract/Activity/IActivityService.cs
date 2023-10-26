using DTO.Activity.Response;
using DTO.Activity.Resquest;
using DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract.Activity
{
    public interface IActivityService
    {
        Task<ApiResponse<GetAllActivityResponse>> getAllTaskDetails();
        Task<ApiResponse<GetAllActivityResponse>> getTaskDetails(IndividualTaskRequest request);
        Task<ApiResponse<GeneralResponse>> addNewTask(NewActivityRequest request);
        Task<ApiResponse<GeneralResponse>> updateTaskDetails(NewActivityRequest request);
        Task<ApiResponse<GeneralResponse>> removeTaskDetails(IndividualTaskRequest request);

    }
}
