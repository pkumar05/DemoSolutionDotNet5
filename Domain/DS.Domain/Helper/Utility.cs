using DS.Domain.DTO;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DM.ApplicationServices.Helper
{
    public static class Utility
    {
        public static ServiceResponse GetValidationResponse(ValidationResult validationResult)
        {
            ServiceResponse response = new ServiceResponse() { success = validationResult.IsValid };
            if (!validationResult.IsValid)
            {
                response.errorlst = new List<ErrorMessage>();
                foreach (var error in validationResult.Errors)
                {
                    response.errorlst.Add(new ErrorMessage

                    {
                        error = error.ErrorCode,
                        value = error.ErrorMessage
                    });
                }

            }
            return response;
        }

        /// <summary>
        /// Method added to provide first letter of each word to be upper case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TitleCase(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input?.ToLower());
        }
        /// <summary>
        /// Method added to provide upper case letter to the word
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UpperCase(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToUpper(input?.ToLower());
        }
        /// <summary>
        /// MEthod added to lower the string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string LowerCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            return CultureInfo.CurrentCulture.TextInfo.ToLower(input?.ToLower());
        }

        public static async Task<bool> ValidateEmail(string userEmail)
        {
            bool isValidEmail = false;
            if (!string.IsNullOrEmpty(userEmail))
                isValidEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$").IsMatch(userEmail);
            return await Task.Run(() => isValidEmail);
        }

    }
}
