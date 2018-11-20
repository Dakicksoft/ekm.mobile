using System;
using System.Collections.Generic;

namespace Ekm.Mobile.Helpers
{
    public static class AppConstants
    {
        // Put constants here that are not of a sensitive nature
        public static string GatewayUrl => "https://api.ekm.net";
        public static string RedirectUri => "http://www.dakicksoft.com";
        public static string ClientKey => "42d5671f-3549-4d67-be7e-1256b527fc0f";
        public static string ClientSecret => "9c3750c6-d009-41e7-8793-20119ea717bc";
        public static Dictionary<string, string> RequiredScopes => new Dictionary<string, string>
        {
            {
                "offline_access",
                "Offline data access"
            },
            {
                "tempest.customers.read",
                "Read a shop's customers."
            },
            {
                "tempest.customers.write",
                "Modify a shop's customers."
            },
            {
                "tempest.orders.read",
                "Read a shops orders."
            },
            {
                "tempest.orders.write",
                "Modify a shop's orders."
            },
            {
                "tempest.products.read",
                "Read a shop's products."
            },
            {
                "tempest.products.write",
                "Modify a shop's products."
            },
            {
                "tempest.categories.read",
                "Read a shop's categories."
            },
            {
                "tempest.categories.write",
                "Modify a shop's categories."
            },
            {
                "tempest.settings.orderstatuses.read",
                "Read a shop's order statuses."
            },
            {
                "tempest.settings.domains.read",
                "Read a shop's domains."
            },
            {
                "tempest.settings.accountdetails.read",
                "Read your account details."
            }
        };
    }
}
