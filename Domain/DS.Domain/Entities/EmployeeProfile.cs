using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS.Domain.Entities
{
    [Table("EmployeeProfile", Schema = "DS")]
    public class EmployeeProfile : BaseEntity
    {
        public string EmployeeDepartmentId { get; set; }
        public string EmployeeProfileId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Descriptions { get; set; }
        public bool Active { get; set; }
    }
}
