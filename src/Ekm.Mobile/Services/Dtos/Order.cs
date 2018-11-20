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

    public partial class Order
    {
        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order(long id, string orderNumber, System.DateTime orderDate, bool isConfirmed, double subTotal, double totalDelivery, double totalTax, double totalCost, string status, string deliveryMethod, string transactionId, string transactionStatus, string orderType, bool useShippingAddress, ShippingAddress shippingAddress, string internalNotes, string customerFacingNotes, bool emailed, string discounts, double discountsTotal, string shippingCompany, string ipAddress, System.Guid guid, string paymentStatus = default(string), System.DateTime? lastUpdated = default(System.DateTime?), IList<OrderItem> items = default(IList<OrderItem>), OrderCustomerDetails customerDetails = default(OrderCustomerDetails))
        {
            Id = id;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
            IsConfirmed = isConfirmed;
            SubTotal = subTotal;
            TotalDelivery = totalDelivery;
            TotalTax = totalTax;
            TotalCost = totalCost;
            Status = status;
            PaymentStatus = paymentStatus;
            DeliveryMethod = deliveryMethod;
            TransactionId = transactionId;
            TransactionStatus = transactionStatus;
            OrderType = orderType;
            UseShippingAddress = useShippingAddress;
            ShippingAddress = shippingAddress;
            InternalNotes = internalNotes;
            CustomerFacingNotes = customerFacingNotes;
            Emailed = emailed;
            Discounts = discounts;
            DiscountsTotal = discountsTotal;
            ShippingCompany = shippingCompany;
            IpAddress = ipAddress;
            Guid = guid;
            LastUpdated = lastUpdated;
            Items = items;
            CustomerDetails = customerDetails;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "order_number")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "order_date")]
        public System.DateTime OrderDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "is_confirmed")]
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sub_total")]
        public double SubTotal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_delivery")]
        public double TotalDelivery { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_tax")]
        public double TotalTax { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total_cost")]
        public double TotalCost { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "payment_status")]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "delivery_method")]
        public string DeliveryMethod { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "transaction_status")]
        public string TransactionStatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "order_type")]
        public string OrderType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "use_shipping_address")]
        public bool UseShippingAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "internal_notes")]
        public string InternalNotes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customer_facing_notes")]
        public string CustomerFacingNotes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emailed")]
        public bool Emailed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discounts")]
        public string Discounts { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "discounts_total")]
        public double DiscountsTotal { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "shipping_company")]
        public string ShippingCompany { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "guid")]
        public System.Guid Guid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "last_updated")]
        public System.DateTime? LastUpdated { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IList<OrderItem> Items { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "customer_details")]
        public OrderCustomerDetails CustomerDetails { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (OrderNumber == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "OrderNumber");
            }
            if (Status == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Status");
            }
            if (DeliveryMethod == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DeliveryMethod");
            }
            if (TransactionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TransactionId");
            }
            if (TransactionStatus == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TransactionStatus");
            }
            if (OrderType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "OrderType");
            }
            if (ShippingAddress == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ShippingAddress");
            }
            if (InternalNotes == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "InternalNotes");
            }
            if (CustomerFacingNotes == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CustomerFacingNotes");
            }
            if (Discounts == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Discounts");
            }
            if (ShippingCompany == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ShippingCompany");
            }
            if (IpAddress == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "IpAddress");
            }
            if (ShippingAddress != null)
            {
                ShippingAddress.Validate();
            }
            if (Items != null)
            {
                foreach (var element in Items)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
