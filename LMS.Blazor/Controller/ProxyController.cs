using LMS.Blazor.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace LMS.Blazor.Controller;

[Route("proxy-endpoint")]
[ApiController]
public class ProxyController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenStorage _tokenService;

    public ProxyController(IHttpClientFactory httpClientFactory, ITokenStorage tokenService)
    {
        _httpClientFactory = httpClientFactory;
        _tokenService = tokenService;
    }


    [Route("{*resource}")]
    [Authorize]
    public async Task<IActionResult> Proxy(string resource)
        {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //Usermanager can be used here! 

        if (userId == null)
            return Unauthorized();

        string endpoint = $"api/{resource}";

        var accessToken = await _tokenService.GetAccessTokenAsync(userId);
        if (resource == "courseForUser")
        {
            endpoint = "api/courses/user";
        }

        if (resource == "userInfo")
        {
            endpoint = $"api/users/{userId}";
        }

        //ToDo: Before continue look for expired accesstoken and call refresh enpoint instead.
        //Better with delegatinghandler or separate service to extract this logic!

        if (string.IsNullOrEmpty(accessToken))
        {
            return Unauthorized();
        }
        var client = _httpClientFactory.CreateClient("LmsAPIClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var targetUri = new Uri($"{client.BaseAddress}{endpoint}{Request.QueryString}");
        var method = new HttpMethod(Request.Method);
        var requestMessage = new HttpRequestMessage(method, targetUri);

        if (method != HttpMethod.Get && Request.ContentLength > 0)
        {

            requestMessage.Content = new StreamContent(Request.Body);

            if (!string.IsNullOrWhiteSpace(Request.ContentType))
            {
                requestMessage.Content.Headers.ContentType
                    = MediaTypeHeaderValue.Parse(Request.ContentType);
            }
        }

        foreach (var header in Request.Headers)
        {
            if (!header.Key.Equals("Host", StringComparison.OrdinalIgnoreCase))
            {
                requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
            }
        }

        var response = await client.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
            return Unauthorized(); //ToDo pass correct statuscode to caller

        Response.StatusCode = (int)response.StatusCode;
        Response.ContentType = response.Content.Headers.ContentType?.ToString() ?? "application/json";

        var stream = await response.Content.ReadAsStreamAsync();
        await stream.CopyToAsync(Response.Body);

        return new EmptyResult();

    }
}