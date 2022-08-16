using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS.Domain.Entities
{
    [Table("Employees", Schema = "DS")]
    public class Employees : BaseEntity
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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
        public string Data { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsGoldMember { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool IsDiamondMember { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
}
