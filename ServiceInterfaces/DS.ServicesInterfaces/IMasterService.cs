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
        Task<ServiceResponse> AddProfile();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<ServiceResponse> GetProfileList(string searchField, string userName);
    }
}
