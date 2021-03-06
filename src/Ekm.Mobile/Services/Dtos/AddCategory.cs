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

    public partial class AddCategory
    {
        /// <summary>
        /// Initializes a new instance of the AddCategory class.
        /// </summary>
        public AddCategory()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AddCategory class.
        /// </summary>
        public AddCategory(string name, string description = default(string), string inCategoryDescription = default(string), string metaDescription = default(string), string metaKeywords = default(string), string metaTitle = default(string), long? orderLocation = default(long?), bool? live = default(bool?), long? parentCategoryId = default(long?))
        {
            Name = name;
            Description = description;
            InCategoryDescription = inCategoryDescription;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            MetaTitle = metaTitle;
            OrderLocation = orderLocation;
            Live = live;
            ParentCategoryId = parentCategoryId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "in_category_description")]
        public string InCategoryDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "meta_description")]
        public string MetaDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "meta_keywords")]
        public string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "meta_title")]
        public string MetaTitle { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "order_location")]
        public long? OrderLocation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "live")]
        public bool? Live { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parent_category_id")]
        public long? ParentCategoryId { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
        }
    }
}
