using DTO.Activity.Data;
using DTO.Activity.Response;
using DTO.Activity.Resquest;
using DTO.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Services.Contract.Activity;
using Services.DBContexts;
using Services.DbDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation.Activity
{
    public class ActivityService :IActivityService
    {
        private readonly OracleDbContext _dbContext;
        public ActivityService(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get All Task Details
        public async Task<ApiResponse<GetAllActivityResponse>> getAllTaskDetails()
        {
            ApiResponse<GetAllActivityResponse> apiResponse = new ApiResponse<GetAllActivityResponse>();
            GetAllActivityResponse getAllActivityResponse = new GetAllActivityResponse();


            try
            {
                getAllActivityResponse.activityDatas = await _dbContext.Tasks.Select(x => new ActivityData { activityDesc = x.TASK_DESC, activityId = x.TASK_ID, activityName = x.TASK_TITLE, dueDate = x.DUE_DATE, status = x.STATUS }).ToListAsync();

                if (getAllActivityResponse.activityDatas.Any())
                {
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "SUCCESS";
                    getAllActivityResponse.isDataAvailable= true;
                    apiResponse.Data = getAllActivityResponse;

                }
                else
                {
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "No Task Available";

                }

            }
            catch (Exception ex)
            {
                apiResponse.Succeeded = false;
                apiResponse.Message = "Internal Server Error";

            }

            return apiResponse;
        }


        #endregion

        #region Get All Task Details
        public async Task<ApiResponse<GetAllActivityResponse>> getTaskDetails(IndividualTaskRequest request)
        {
            ApiResponse<GetAllActivityResponse> apiResponse = new ApiResponse<GetAllActivityResponse>();
            GetAllActivityResponse getAllActivityResponse = new GetAllActivityResponse();


            try
            {
                getAllActivityResponse.activityDatas = await _dbContext.Tasks.Where(y=>y.TASK_ID==request.taskId).Select(x => new ActivityData { activityDesc = x.TASK_DESC, activityId = x.TASK_ID, activityName = x.TASK_TITLE, dueDate = x.DUE_DATE, status = x.STATUS }).ToListAsync();

                if (getAllActivityResponse.activityDatas.Any())
                {
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "SUCCESS";
                    getAllActivityResponse.isDataAvailable = true;
                    apiResponse.Data = getAllActivityResponse;

                }
                else
                {
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "No Task Available";

                }

            }
            catch (Exception ex)
            {
                apiResponse.Succeeded = false;
                apiResponse.Message = "Internal Server Error";

            }

            return apiResponse;
        }


        #endregion

        #region Add new Task
        public async Task<ApiResponse<GeneralResponse>> addNewTask(NewActivityRequest request)
        {

            ApiResponse<GeneralResponse> apiResponse = new ApiResponse<GeneralResponse>();
            GeneralResponse generalResponse = new GeneralResponse();
            try
            {

                var taskId_ =  _dbContext.Tasks.Select(x=>x.TASK_ID).Max();


                TaskInfo taskInfo = new TaskInfo()
                {
                    TASK_ID = taskId_+1,
                    DUE_DATE = request.dueDate,
                    TASK_DESC = request.activityDesc,
                    TASK_TITLE = request.activityName,
                    CREATED_BY = request.createdBy,
                    CREATED_DATE = DateTime.Now,
                    STATUS=request.status,
                    MODIFIED_BY=null,
                };


               var temp= _dbContext.Tasks.Add(taskInfo);
               if ( _dbContext.SaveChanges() > 0)
                {
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "SUCCESS";
                    generalResponse.isSucceeded = true;
                    generalResponse.responseMsg = "Task Added";
                    apiResponse.Data = generalResponse;
                }
                else
                {
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "Insertion failed...";

                }


            }
            catch (Exception ex)
            {
                apiResponse.Succeeded = false;
                apiResponse.Message = "Internal Server Error";
            }

            return apiResponse;
        }
        #endregion


        #region Update Task Details
        public async Task<ApiResponse<GeneralResponse>> updateTaskDetails(NewActivityRequest request)
        {
            ApiResponse<GeneralResponse> apiResponse = new ApiResponse<GeneralResponse>();
            GeneralResponse generalResponse = new GeneralResponse();
            try
            {
               

                var data= _dbContext.Tasks.FirstOrDefault(item => item.TASK_ID == request.activityId);

               
                if (data != null)
                {
                    data.TASK_TITLE =  request.activityName;
                    data.TASK_DESC =  request.activityDesc;
                    data.STATUS =  request.status;
                    
                    data.MODIFIED_BY =  request.createdBy;
                    data.MODIFIED_DATE = DateTime.Now;
                    data.DUE_DATE = request.dueDate;
                    _dbContext.Entry(data).State = EntityState.Modified;
                   
                    if(_dbContext.SaveChanges() > 0)
                    {
                        apiResponse.Succeeded = true;
                        apiResponse.Message = "SUCCESS";
                        generalResponse.isSucceeded = true;
                        generalResponse.responseMsg = "Task Updated";
                        apiResponse.Data = generalResponse;
                    }
                    else
                    {
                        apiResponse.Succeeded = true;
                        apiResponse.Message = "Updation failed...";

                    }

                }
                else
                {
                    apiResponse.Succeeded = false;
                    apiResponse.Message = "No Data Found";
                }
            }
            catch (Exception ex)
            {
                apiResponse.Succeeded = false;
                apiResponse.Message = "Internal Server Error";
            }
            return apiResponse;
        }

        #endregion

        #region Remove Task
        public async Task<ApiResponse<GeneralResponse>> removeTaskDetails(IndividualTaskRequest request)
        {
            ApiResponse<GeneralResponse> apiResponse = new ApiResponse<GeneralResponse>();
            GeneralResponse generalResponse = new GeneralResponse();
            try
            {

                TaskInfo taskInfo = new TaskInfo()
                {

                   TASK_ID=request.taskId

                };

                
                    _dbContext.Tasks.Attach(taskInfo);
                    _dbContext.Tasks.Remove(taskInfo);

                if (_dbContext.SaveChanges() > 0)
                {


                    generalResponse.responseMsg = "Task Removed";
                    generalResponse.isSucceeded = true;
                    apiResponse.Data = generalResponse;
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "SUCCESS";

                }
                else
                {
                    generalResponse.responseMsg = "Failed";
                    generalResponse.isSucceeded = false;
                    apiResponse.Data = generalResponse;
                    apiResponse.Succeeded = true;
                    apiResponse.Message = "Fail";
                }


            }catch(Exception ex)
            {
                apiResponse.Succeeded = false;
                apiResponse.Message = "Internal Server Error";
            }

            return apiResponse;
        }


        #endregion
    }
}
