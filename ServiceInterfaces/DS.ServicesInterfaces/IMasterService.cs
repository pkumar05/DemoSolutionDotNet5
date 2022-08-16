using DS.Domain.DTO;
using System.Threading.Tasks;

namespace DS.ServicesInterfaces
{
    public interface IMasterService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        Task<ServiceResponse> AddDepartment(AddDepartmentRequest request, string createdBy);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetDepartmentList(string searchField, string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse> UpdateDepartment(UpdateDepartmentRequest request,string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse> AddProfile(AddProfileRequest request, string createdBy);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetProfileList(string searchField, string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateProfile(UpdateProfileRequest request, string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse> AddEmployee(AddEmployeeRequest request, string cretedBy);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetEmployeeList(string searchField, string userName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ServiceResponse> UpdateEmployee(UpdateEmpoyeeRequest request, string userName);
    }
}
