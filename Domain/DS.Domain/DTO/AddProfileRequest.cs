namespace DS.Domain.DTO
{
    public class AddProfileRequest
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

    public class UpdateProfileRequest : AddProfileRequest
    {
        public string Id { get; set; }

        private new bool Active { get; set; }
    }
}
