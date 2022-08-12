using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS.Domain.Entities
{
    [Table("Departments", Schema = "DS")]
    public class Departments : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Descriptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
}
