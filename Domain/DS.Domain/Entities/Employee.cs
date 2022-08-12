using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS.Domain.Entities
{
    [Table("Employee", Schema = "DS")]
    public class Employee : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HomeAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CurrentTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsGoldMember { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDiamondMember { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
}
