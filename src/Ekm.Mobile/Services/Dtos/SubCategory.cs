// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Ekm.Mobile.Services.Dtos
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class SubCategory
    {
        /// <summary>
        /// Initializes a new instance of the SubCategory class.
        /// </summary>
        public SubCategory()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SubCategory class.
        /// </summary>
        public SubCategory(long? parentCategoryId = default(long?), long? categoryId = default(long?), string name = default(string), string description = default(string), long? orderLocation = default(long?), bool? live = default(bool?), bool? isCategoryManaged = default(bool?))
        {
            ParentCategoryId = parentCategoryId;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            OrderLocation = orderLocation;
            Live = live;
            IsCategoryManaged = isCategoryManaged;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "parent_category_id")]
        public long? ParentCategoryId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "category_id")]
        public long? CategoryId { get; set; }

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
        [JsonProperty(PropertyName = "order_location")]
        public long? OrderLocation { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "live")]
        public bool? Live { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "is_category_managed")]
        public bool? IsCategoryManaged { get; set; }

    }
}
