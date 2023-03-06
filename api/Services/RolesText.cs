
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services
{
    public static class RolesText
    {
        public const string ADMIN = "ADMIN";
        public const string SHOP = "SHOP";
        public const string APPROVING_SHOP = "APPROVING_SHOP";
        public const string CUSTOMER = "CUSTOMER";
        public const string PARTNER = "PARTNER";
        public const string DELIVERY_MAN = "DELIVERY_MAN";
    }
}