using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.Domain.DTO
{
    public  class AddDepartmentRequest
    {
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

    public class UpdateDepartmentRequest : AddDepartmentRequest
    {
        public string Id { get; set; } 

        private new bool Active { get; set; }
    }
}
