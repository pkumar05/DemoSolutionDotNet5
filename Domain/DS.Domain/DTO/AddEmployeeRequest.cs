namespace DS.Domain.DTO
{
    public class AddEmployeeRequest
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
       // public int EmployeeID { get; set; }
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
        public Data Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }

    public class Data { }

    public class UpdateEmpoyeeRequest : AddEmployeeRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private new bool Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private new string CurrentTitle { get; set; }
    }
}
