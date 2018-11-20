﻿// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Ekm.Mobile.Services.Dtos
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ValidationError
    {
        /// <summary>
        /// Initializes a new instance of the TempestValidationError class.
        /// </summary>
        public ValidationError()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TempestValidationError class.
        /// </summary>
        public ValidationError(IList<string> memberNames = default(IList<string>), string errorMessage = default(string))
        {
            MemberNames = memberNames;
            ErrorMessage = errorMessage;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "member_names")]
        public IList<string> MemberNames { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }

    }
}
