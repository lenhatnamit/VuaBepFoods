using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using static System.String;

namespace VuaBepFoodsWeb.Lib
{
    public static class SecurityManager
    {
        public class AuthResult
        {
            public string token { get; set; }
            public string expire { get; set; }
            public string expireUtc7 { get; set; }
            public long expireUtc7Long { get; set; }
            public string tokenRefresh { get; set; }
            public bool success { get; set; }
        }
        public class M_AccountSecurity
        {
            public string accessLogId { get; set; }
            public string accountId { get; set; }
            public string userId { get; set; }
            public string userName { get; set; }
            public string password { get; set; }
            public string name { get; set; }
            public string supplierId { get; set; }
            public string supplierName { get; set; }
            public string supplierRefCode { get; set; }
            public string domainName { get; set; }
            public string avatar { get; set; }
            public bool stayLoggedIn { get; set; }
            public int timeOut { get; set; } = 30;
            public int isDefault { get; set; }
            public string accessToken { get; set; }
            public string accessTokenRefresh { get; set; }
            public string accessTokenExpired { get; set; }
            public string accessTokenExpiredUtc7 { get; set; }
            public string accessTokenExpiredUtc7Long { get; set; }
            public int isManySupplier { get; set; }
            public DateTimeOffset? cookiesIntervalTimeOut { get; set; }
            public List<string> role { get; set; }
            public string roleId { get; set; }
        }
        private static IEnumerable<Claim> getUserClaims(M_AccountSecurity account)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("AccessLogId", IsNullOrEmpty(account.accessLogId) ? "" : account.accessLogId),
                new Claim("AccountId", account.accountId),
                new Claim("UserId", account.userId),
                new Claim(ClaimTypes.NameIdentifier, account.userName),
                new Claim(ClaimTypes.Name, account.name),
                new Claim("Password", account.password),
                new Claim("Avatar", account.avatar),
                new Claim("TimeCheck", Utilities.DateTimeToLong(DateTime.UtcNow.AddHours(7).AddMinutes(CommonConstants.TIMEOUT_CHECK_AUTHENTICATION)).ToString()),
                new Claim("SupplierId", IsNullOrEmpty(account.supplierId) ? "" : account.supplierId),
                new Claim("SupplierName", IsNullOrEmpty(account.supplierName) ? "" : account.supplierName),
                new Claim("SupplierRefCode", IsNullOrEmpty(account.supplierRefCode) ? "" : account.supplierRefCode),
                new Claim("RoleId", IsNullOrEmpty(account.roleId) ? "" : account.roleId),
                new Claim("IsDefault", account.isDefault.ToString()),
                new Claim("AccessToken", account.accessToken),
                new Claim("AccessTokenRefresh", IsNullOrEmpty(account.accessTokenRefresh) ? "" : account.accessTokenRefresh),
                new Claim("AccessTokenExpired", IsNullOrEmpty(account.accessTokenExpired) ? "" : account.accessTokenExpired),
                new Claim("AccessTokenExpiredUtc7", IsNullOrEmpty(account.accessTokenExpiredUtc7) ? "" : account.accessTokenExpiredUtc7),
                new Claim("AccessTokenExpiredUtc7Long", IsNullOrEmpty(account.accessTokenExpiredUtc7Long) ? "" :account.accessTokenExpiredUtc7Long),
                new Claim("IntervalTime", account.timeOut.ToString()),
                new Claim("IsManySupplier", account.isManySupplier.ToString()),
                new Claim("IsPersistent", account.stayLoggedIn.ToString())
            };
            account.role?.ForEach((x) => { claims.Add(new Claim(ClaimTypes.Role, IsNullOrEmpty(x) ? "" : x)); });
            return claims;
        }
        public static async void SignIn(HttpContext httpContext, M_AccountSecurity account, string scheme)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account), scheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(
                scheme: scheme,
                principal: claimsPrincipal,
                properties: new AuthenticationProperties
                {
                    //AllowRefresh = true,//Refreshing the authentication session should be allowed.
                    ExpiresUtc = account.cookiesIntervalTimeOut, //The time at which the authentication ticket expires. A value set here overrides the ExpireTimeSpan option of CookieAuthenticationOptions set with AddCookie
                    IsPersistent = account.stayLoggedIn,//Whether the authentication session is persisted across  multiple requests. When used withcookies, controls whether the cookie's lifetime is absolute (matching the lifetime of the authentication ticket) or session-based
                    //IssuedUtc = DateTime.UtcNow, //The time at which the authentication ticket was issued. 
                });
        }
        public static async void SignOut(HttpContext httpContext, string scheme)
        {
            if (httpContext.Request.Cookies.Count > 0)
            {
                httpContext.Response.Cookies.Delete("Authentication");
                //foreach (var cookie in httpContext.Request.Cookies.Keys)
                //    httpContext.Response.Cookies.Delete(cookie);
            }
            await httpContext.SignOutAsync(scheme);
            httpContext.Session.Clear();
        }
    }
}
