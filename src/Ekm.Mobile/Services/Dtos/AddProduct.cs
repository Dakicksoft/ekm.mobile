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

    public partial class AddProduct
    {
        /// <summary>
        /// Initializes a new instance of the AddProduct class.
        /// </summary>
        public AddProduct()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AddProduct class.
        /// </summary>
        public AddProduct(string name, long? categoryId = default(long?), string description = default(string), string shortDescription = default(string), long? numberInStock = default(long?), double? price = default(double?), double? rrp = default(double?), string productCode = default(string), bool? chargeDelivery = default(bool?), bool? specialOffer = default(bool?), string brand = default(string), string condition = default(string), string gtin = default(string), string mpn = default(string), double? productWeight = default(double?), bool? canBeAddedToCart = default(bool?), bool? taxApplicable = default(bool?), bool? live = default(bool?), string orderNote = default(string), string redirectUrl = default(string), System.DateTime? lastModified = default(System.DateTime?), string metaDescription = default(string), string metaKeywords = default(string), string metaTitle = default(string), long? totalProductStock = default(long?))
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            NumberInStock = numberInStock;
            Price = price;
            Rrp = rrp;
            ProductCode = productCode;
            ChargeDelivery = chargeDelivery;
            SpecialOffer = specialOffer;
            Brand = brand;
            Condition = condition;
            Gtin = gtin;
            Mpn = mpn;
            ProductWeight = productWeight;
            CanBeAddedToCart = canBeAddedToCart;
            TaxApplicable = taxApplicable;
            Live = live;
            OrderNote = orderNote;
            RedirectUrl = redirectUrl;
            LastModified = lastModified;
            MetaDescription = metaDescription;
            MetaKeywords = metaKeywords;
            MetaTitle = metaTitle;
            TotalProductStock = totalProductStock;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

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
        [JsonProperty(PropertyName = "short_description")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "number_in_stock")]
        public long? NumberInStock { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public double? Price { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rrp")]
        public double? Rrp { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "product_code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "charge_delivery")]
        public bool? ChargeDelivery { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "special_offer")]
        public bool? SpecialOffer { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "brand")]
        public string Brand { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gtin")]
        public string Gtin { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mpn")]
        public string Mpn { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "product_weight")]
        public double? ProductWeight { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "can_be_added_to_cart")]
        public bool? CanBeAddedToCart { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tax_applicable")]
        public bool? TaxApplicable { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "live")]
        public bool? Live { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "order_note")]
        public string OrderNote { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "redirect_url")]
        public string RedirectUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_modified")]
        public System.DateTime? LastModified { get; set; }

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
        [JsonProperty(PropertyName = "total_product_stock")]
        public long? TotalProductStock { get; set; }

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
            if (Price < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Price", 0);
            }
            if (Rrp < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Rrp", 0);
            }
            if (ProductWeight < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "ProductWeight", 0);
            }
        }
    }
}
