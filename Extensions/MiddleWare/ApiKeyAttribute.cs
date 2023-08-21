using Microsoft.AspNetCore.Mvc;

namespace UserManagementApi.Extensions.MiddleWare
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
            : base(typeof(UserAuthorizeAttribute))
        {
        }
    }
}
