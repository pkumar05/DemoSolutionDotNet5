using DS.Domain.DTO;
using DS.ServicesInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.DemoSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [EnableCors("*")]
    // [Authorize]  // Remove this later as it need to be authorize
    public class MasterController : DemoSolutionControllerBase
    {
        #region Commented Codes
        //// GET: api/<MasterController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<MasterController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<MasterController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MasterController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MasterController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService,
            ILogger<MasterController> logger
            ) : base(logger)
        {
            _masterService = masterService;
        }

        /// <summary>
        /// Method added to create Department.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddDepartment")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "CREATE")]
        public async Task<IActionResult> AddDepartment(AddDepartmentRequest request)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> AddDepartment method ");
            try
            {
                var result = await _masterService.AddDepartment(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->AddDepartment method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// Method added to get Department list.
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpGet]
        // [Route("GetDepartmentList/{searchfield}")]
        [Route("GetDepartmentList")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "READ")]
        public async Task<IActionResult> GetDepartmentList(string searchField)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> GetDepartmentList method ");
            try
            {
                var result = await _masterService.GetDepartmentList(searchField, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->GetDepartmentList method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// MEthod added to edit department details
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpPut]
        // [Route("GetDepartmentList/{searchfield}")]
        [Route("UpdateDepartment")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "READ")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentRequest request)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> UpdateDepartment method ");
            try
            {
                var result = await _masterService.UpdateDepartment(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->UpdateDepartment method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// Method added to create profile.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProfile")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "CREATE")]
        public async Task<IActionResult> AddProfile(AddProfileRequest request)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> AddProfile method ");
            try
            {
                var result = await _masterService.AddProfile(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->AddProfile method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// Method added to get profile list.
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpGet]
        // [Route("GetDepartmentList/{searchfield}")]
        [Route("GetProfileList")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "READ")]
        public async Task<IActionResult> GetProfileList(string searchField)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> GetProfileList method ");
            try
            {
                var result = await _masterService.GetProfileList(searchField, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->GetProfileList method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// MEthod added to update profile data.
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpPut]
        // [Route("GetDepartmentList/{searchfield}")]
        [Route("UpdateProfile")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "UPDATE")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileRequest request)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> UpdateProfile method ");
            try
            {
                var result = await _masterService.UpdateProfile(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->UpdateProfile method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// Method added to add Employee.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddEmployee")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "CREATE")]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest request)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> AddEmployee method ");
            try
            {
                var result = await _masterService.AddEmployee(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->AddEmployee method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// Method added to get list of employee.
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpGet]
        // [Route("GetDepartmentList/{searchfield}")]
        [Route("GetEmployeeList")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "READ")]
        public async Task<IActionResult> GetEmployeeList(string searchField)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> GetEmployeeList method ");
            try
            {
                var result = await _masterService.GetEmployeeList(searchField, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->GetEmployeeList method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// Method added to update Employee data.
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpPut]
        // [Route("GetDepartmentList/{searchfield}")]
        [Route("UpdateEmployee")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "UPDATE")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmpoyeeRequest request)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> UpdateEmployee method ");
            try
            {
                var result = await _masterService.UpdateEmployee(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->UpdateEmployee method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

    }
}
