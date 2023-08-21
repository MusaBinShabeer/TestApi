using Microsoft.Extensions.Configuration;

namespace UserManagementApi.Repositories.ApiKeyServiceRepo
{
    public interface IApiKeyService
    {
        public bool IsValid(string apiKey);
    }
}
