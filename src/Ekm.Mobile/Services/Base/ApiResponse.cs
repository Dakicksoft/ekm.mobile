using System.Collections.Generic;
using Ekm.Mobile.Services.Dtos;
using Newtonsoft.Json;

namespace Ekm.Mobile.Services
{
    public class ApiResponse<T> where T : class
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "meta")]
        public IDictionary<string, object> Meta { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "links")]
        public IList<Link> Links { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "validation_result")]
        public IList<ValidationError> ValidationResult { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "errors")]
        public IDictionary<string, string> Errors { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //if (Data != null)
            //{
            //    Data.Validate();
            //}
        }

    }
}
