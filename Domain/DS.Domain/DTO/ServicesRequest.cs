using System.ComponentModel.DataAnnotations;

namespace DS.Domain.DTO
{
    public class ServicesRequest
    {
        /// <summary>
        /// Property added to get/set  Service Name
        /// </summary>
        [Required]
        [RegularExpression(@"[\p{L}_ ]+$", ErrorMessage = "Please provide valid Service Name. Only alphabets,space and underscore allowed.")]
        [StringLength(maximumLength: 255, MinimumLength = 2)]
        public string Name { get; set; }
        /// <summary>
        /// Property added to Service Active/Deactive
        /// </summary>
        [Required]
        public bool Active { get; set; }
        /// <summary>
        /// Property added to retrieve user remarks
        /// </summary>
        [StringLength(maximumLength: 255, MinimumLength = 0, ErrorMessage = "Maximum 255 characters are allowed.")]
        public string Remarks { get; set; }
    }


    public class ModifyServiceDataRequest : ServicesRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string ServiceID { get; set; }
    }
}
