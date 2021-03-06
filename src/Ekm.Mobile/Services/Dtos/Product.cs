// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Ekm.Mobile.Services.Dtos
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Product
    {
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Product(string name, long? id = default(long?), long? categoryId = default(long?), string description = default(string), string shortDescription = default(string), long? numberInStock = default(long?), double? price = default(double?), double? rrp = default(double?), string productCode = default(string), bool? chargeDelivery = default(bool?), bool? specialOffer = default(bool?), string brand = default(string), string condition = default(string), string gtin = default(string), string mpn = default(string), double? productWeight = default(double?), bool? canBeAddedToCart = default(bool?), bool? taxApplicable = default(bool?), bool? live = default(bool?), string orderNote = default(string), string redirectUrl = default(string), System.DateTime? lastModified = default(System.DateTime?), string metaDescription = default(string), string metaKeywords = default(string), string metaTitle = default(string), long? totalProductStock = default(long?), long? parentProductId = default(long?), IList<ProductOption> options = default(IList<ProductOption>), IList<ProductVariant> variants = default(IList<ProductVariant>), IList<ProductCategory> categories = default(IList<ProductCategory>), IList<ProductAttributeItem> attributeItems = default(IList<ProductAttributeItem>), string seoFriendlyUrl = default(string))
        {
            Id = id;
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
            ParentProductId = parentProductId;
            Options = options;
            Variants = variants;
            Categories = categories;
            AttributeItems = attributeItems;
            SeoFriendlyUrl = seoFriendlyUrl;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

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
        /// </summary>
        [JsonProperty(PropertyName = "parent_product_id")]
        public long? ParentProductId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "options")]
        public IList<ProductOption> Options { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "variants")]
        public IList<ProductVariant> Variants { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public IList<ProductCategory> Categories { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attribute_items")]
        public IList<ProductAttributeItem> AttributeItems { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "seo_friendly_url")]
        public string SeoFriendlyUrl { get; private set; }

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
            if (Options != null)
            {
                foreach (var element in Options)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (Variants != null)
            {
                foreach (var element1 in Variants)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
        }
    }
}
