using DS.Domain.DTO;
using DS.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DS.ApplicationServices.Command
{
    public static class CreateProfileCommand
    {
        /// <summary>
        /// Create command to add new Profile.
        /// </summary>
        /// <param name="department"></param>
        /// <param name="request"></param>
        /// <param name="createdBy"></param>
        /// <returns></returns>
        internal static async Task<Profile> CreateProfile(AddProfileRequest request, string createdBy)
        {
            Profile profile = new Profile
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Code = request.Code,
                Descriptions = request.Descriptions,
                Active = true,
                CreatedBy = createdBy,
                CreatedDate = DateTime.Now,

            };

            return await Task.Run(() => profile);

        }


    }
}
