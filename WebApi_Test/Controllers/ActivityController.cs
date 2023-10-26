using DTO.Activity.Resquest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contract.Activity;
using WebApi_Test.Auth;

namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ActivityController : ControllerBase
    {

        private IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {

            _activityService = activityService;
        }

        
        [HttpGet("getAllTaskDtls")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAllTaskDtls()
        {
            

                return Ok(await _activityService.getAllTaskDetails());
            
        }


        
        [HttpPost("getTaskDtlsById")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> getTaskDtls(IndividualTaskRequest request)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _activityService.getTaskDetails(request));
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        
        [HttpPost("addNewTask")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> addNewTask(NewActivityRequest request)
        {
            if (ModelState.IsValid)
            {

                return Ok(await _activityService.addNewTask(request));
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        
        [HttpPost("updateTaskDetails")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> updateTaskDetails(NewActivityRequest request)
        {
            if (ModelState.IsValid)
            {
                if (0==request.activityId)
                {
                    return BadRequest(ModelState);
                }
                else
                {

                    return Ok(await _activityService.updateTaskDetails(request));
                }
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        
        [HttpPost("removeTaskDetails")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> removeTaskDetails(IndividualTaskRequest request)
        {
            if(ModelState.IsValid)
            {

                return Ok(await _activityService.removeTaskDetails(request));
            }
            else
            {
                return BadRequest(ModelState);
            }


        }
    }
}
