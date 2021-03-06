// <auto-generated>
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

    public partial class Plan
    {
        /// <summary>
        /// Initializes a new instance of the Plan class.
        /// </summary>
        public Plan()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Plan class.
        /// </summary>
        public Plan(string id = default(string), int? order = default(int?), string friendlyName = default(string), string description = default(string), IList<PlanRestriction> restrictions = default(IList<PlanRestriction>))
        {
            Id = id;
            Order = order;
            FriendlyName = friendlyName;
            Description = description;
            Restrictions = restrictions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "order")]
        public int? Order { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "friendly_name")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "restrictions")]
        public IList<PlanRestriction> Restrictions { get; set; }

    }
}
