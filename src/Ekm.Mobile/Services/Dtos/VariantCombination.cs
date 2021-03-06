// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Ekm.Mobile.Services.Dtos
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class VariantCombination
    {
        /// <summary>
        /// Initializes a new instance of the VariantCombination class.
        /// </summary>
        public VariantCombination()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VariantCombination class.
        /// </summary>
        public VariantCombination(string variantName, string variantChoice)
        {
            VariantName = variantName;
            VariantChoice = variantChoice;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "variant_name")]
        public string VariantName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "variant_choice")]
        public string VariantChoice { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (VariantName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VariantName");
            }
            if (VariantChoice == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VariantChoice");
            }
        }
    }
}
