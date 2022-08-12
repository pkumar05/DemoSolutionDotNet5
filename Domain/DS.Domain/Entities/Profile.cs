using PK.BuildingBlocks.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace DS.Domain.Entities
{
    [Table("Profile", Schema = "DS")]
    public class Profile : BaseEntity
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
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
}
