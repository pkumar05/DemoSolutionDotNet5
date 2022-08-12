using DS.Domain.DTO;
using DS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ApplicationServices.Command
{
    public static class CreateDepartmentCommand
    {
        /// <summary>
        /// Create command to add new department.
        /// </summary>
        /// <param name="department"></param>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        internal static async Task<Departments> CreateDepartment(AddDepartmentRequest request, string createdBy)
        {
            Departments department = new Departments
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Code = request.Code,
                Descriptions = request.Descriptions,
                Active = true,
                CreatedBy = createdBy,
                CreatedDate = DateTime.Now,

            };

            return await Task.Run(() => department);

        }


    }
}
