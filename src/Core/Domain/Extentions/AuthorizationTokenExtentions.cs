using System.Net.Http.Headers;

namespace Domain.Extensions.API;

public static class AuthorizationTokenExtension
{
    public static void PutTokenInHeaderAuthorization(this HttpClient client, string token)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}
