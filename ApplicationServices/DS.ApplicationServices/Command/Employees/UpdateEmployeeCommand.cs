using DS.Domain.DTO;
using DS.Domain.Entities;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace DS.ApplicationServices.Command
{
    public static class UpdateEmployeeCommand
    {
        /// <summary>
        /// Update command to edit employee details.
        /// </summary>
        /// <param name="department"></param>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        internal static async Task<Employees> UpdateEmployee(Employees emp, UpdateEmpoyeeRequest request, string modifyBy)
        {

            emp.FirstName = request.FirstName ?? emp.FirstName;
            emp.MiddleName = request.MiddleName ?? emp.MiddleName;
            emp.LastName = request.LastName ?? emp.LastName;
            emp.Email = request.Email ?? emp.Email;
            emp.Phone = request.Phone ?? emp.Phone;
            emp.HomeAddress = request.HomeAddress ?? emp.HomeAddress;
            emp.Data = JsonSerializer.Serialize(request.Data) ?? JsonSerializer.Serialize(emp.Data);
            emp.UpdatedBy = modifyBy;
            emp.UpdatedDate = DateTime.Now;

            return await Task.Run(() => emp);

        }


    }
}
