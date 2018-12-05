// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Ekm.Mobile.Services.Dtos
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class OrderCustomerDetails
    {
        /// <summary>
        /// Initializes a new instance of the OrderCustomerDetails class.
        /// </summary>
        public OrderCustomerDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OrderCustomerDetails class.
        /// </summary>
        public OrderCustomerDetails(long? customerId = default(long?), string emailAddress = default(string), string firstName = default(string), string lastName = default(string), string company = default(string), string address = default(string), string address2 = default(string), string town = default(string), string county = default(string), string country = default(string), string postCode = default(string), string telephone = default(string), string fax = default(string), bool? billingAddressVerified = default(bool?))
        {
            CustomerId = customerId;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            Address = address;
            Address2 = address2;
            Town = town;
            County = county;
            Country = country;
            PostCode = postCode;
            Telephone = telephone;
            Fax = fax;
            BillingAddressVerified = billingAddressVerified;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customer_id")]
        public long? CustomerId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "email_address")]
        public string EmailAddress { get; set; }

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
        /// </summary>
        [JsonProperty(PropertyName = "billing_address_verified")]
        public bool? BillingAddressVerified { get; set; }

    }
}