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

    public partial class ShippingAddress
    {
        /// <summary>
        /// Initializes a new instance of the ShippingAddress class.
        /// </summary>
        public ShippingAddress()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ShippingAddress class.
        /// </summary>
        public ShippingAddress(string firstName, string lastName, string address, string town, string country, string postCode, long? id = default(long?), System.DateTime? createdDate = default(System.DateTime?), System.DateTime? modifiedDate = default(System.DateTime?), long? customerId = default(long?), bool? isPreferredBillingAddress = default(bool?), bool? isPreferredShippingAddress = default(bool?), string company = default(string), string address2 = default(string), string county = default(string), string friendlyCountry = default(string), string telephone = default(string), string fax = default(string))
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            CustomerId = customerId;
            IsPreferredBillingAddress = isPreferredBillingAddress;
            IsPreferredShippingAddress = isPreferredShippingAddress;
            Company = company;
            Address = address;
            Address2 = address2;
            Town = town;
            County = county;
            Country = country;
            FriendlyCountry = friendlyCountry;
            PostCode = postCode;
            Telephone = telephone;
            Fax = fax;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "created_date")]
        public System.DateTime? CreatedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "modified_date")]
        public System.DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customer_id")]
        public long? CustomerId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "is_preferred_billing_address")]
        public bool? IsPreferredBillingAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "is_preferred_shipping_address")]
        public bool? IsPreferredShippingAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "address2")]
        public string Address2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "town")]
        public string Town { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "county")]
        public string County { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "friendly_country")]
        public string FriendlyCountry { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "post_code")]
        public string PostCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (FirstName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FirstName");
            }
            if (LastName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "LastName");
            }
            if (Address == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Address");
            }
            if (Town == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Town");
            }
            if (Country == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Country");
            }
            if (PostCode == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PostCode");
            }
        }
    }
}
