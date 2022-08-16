namespace DS.Domain.DTO
{
    public class AddDepartmentRequest
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

    public class UpdateDepartmentRequest : AddDepartmentRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private new bool Active { get; set; }
    }
}
