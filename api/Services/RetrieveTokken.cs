using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace Services
{
    public static class RetrieveToken
    {

        public static int GetIdUser(this HttpContext context)
        {
            return int.Parse(context.User?.Identity?.Name);
        }

        public static string GetRoleUser(this HttpContext context)
        {
            return context.User.Claims.SingleOrDefault(e => e.Type == ClaimTypes.Role)?.Value;
        }

        public static string GetClaim(this HttpContext context, string type)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            // var token0 = await context.GetTokenAsync("name");
            // var me = context.User.Claims;
            string tokenString = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            JwtSecurityToken  token = tokenHandler.ReadJwtToken(tokenString);
            Claim claim = token.Claims.SingleOrDefault(e => e.Type == type);

            return claim?.Value;
        }


        public static string GetClaimfromToken(this HttpContext context, string type,string tokenStr)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
         
            JwtSecurityToken  token = tokenHandler.ReadJwtToken(tokenStr);
            Claim claim = token.Claims.SingleOrDefault(e => e.Type == type);

            return claim?.Value;
        }


    }
}