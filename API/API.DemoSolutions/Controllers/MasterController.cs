using DS.Domain.DTO;
using DS.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.DemoSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddDepartment")]
        //[HasPermission(ProcessName = "MASTER", SubProcessName = "CREATE")]
        public async Task<IActionResult> AddCustomer(AddDepartmentRequest request)
        {
            string user = User.Identity.Name;
            Serilog.Log.Information("Started --Log Of Master--> AddCustomer method ");
            try
            {
                var result = await _masterService.AddDepartment(request, user);
                return Ok(result);
            }

            catch (Exception ex)
            {
                Serilog.Log.Error("Error: Log Of Master-->AddCustomer method Error:", ex.Data);
                return HandleUserException(ex);
            }
        }

        /// <summary>
        /// 
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
        /// MEthod added to update department data
        /// </summary>
        /// <param name="searchField"></param>
        /// <returns></returns>
        [HttpPost]
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

    }
}
