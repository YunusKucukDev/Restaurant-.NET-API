using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Restaurant.DtoLayer.IdentityDtos.LoginDtos;
using Restaurant.WebUI.Services.Interfaces;
using Restaurant.WebUI.settings;
using System.Security.Claims;

namespace Restaurant.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ClientSettings> clientSettings,
            IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        
        public async Task<bool> SignIn(SignInDto signInDto)
        {
            // 1️⃣ Discovery
            var discovery = await _httpClient.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = { RequireHttps = false }
                });

            if (discovery.IsError)
                throw new Exception(discovery.Error);

            // 2️⃣ Password Token Request (⚠️ scope çok önemli)
            var tokenResponse = await _httpClient.RequestPasswordTokenAsync(
                new PasswordTokenRequest
                {
                    Address = discovery.TokenEndpoint,
                    ClientId = _clientSettings.restaurantManagerClient.ClientId,
                    ClientSecret = _clientSettings.restaurantManagerClient.ClientSecret,
                    UserName = signInDto.Username,
                    Password = signInDto.Password,
                });

            if (tokenResponse.IsError || string.IsNullOrEmpty(tokenResponse.AccessToken))
                throw new Exception(tokenResponse.Error ?? "Access token alınamadı");

            // 3️⃣ UserInfo
            var userInfo = await _httpClient.GetUserInfoAsync(
                new UserInfoRequest
                {
                    Address = discovery.UserInfoEndpoint,
                    Token = tokenResponse.AccessToken
                });

            if (userInfo.IsError)
                throw new Exception(userInfo.Error);

            // 4️⃣ Claims
            var claimsIdentity = new ClaimsIdentity(
                userInfo.Claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                "name",
                "role");

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // 5️⃣ Cookie + Token Store
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false
            };

            authProperties.StoreTokens(new List<AuthenticationToken>
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = tokenResponse.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = tokenResponse.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.UtcNow
                        .AddSeconds(tokenResponse.ExpiresIn)
                        .ToString("o")
                }
            });

            await _httpContextAccessor.HttpContext!.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties);

            return true;
        }

        // =========================
        // REFRESH TOKEN
        // =========================
        public async Task<bool> GetRefreshToken()
        {
            var discovery = await _httpClient.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = { RequireHttps = false }
                });

            if (discovery.IsError)
                throw new Exception(discovery.Error);

            var refreshToken = await _httpContextAccessor.HttpContext!
                .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            if (string.IsNullOrEmpty(refreshToken))
                return false;

            var tokenResponse = await _httpClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    Address = discovery.TokenEndpoint,
                    ClientId = _clientSettings.restaurantManagerClient.ClientId,
                    ClientSecret = _clientSettings.restaurantManagerClient.ClientSecret,
                    RefreshToken = refreshToken
                });

            if (tokenResponse.IsError)
                throw new Exception(tokenResponse.Error);

            var authenticateResult =
                await _httpContextAccessor.HttpContext.AuthenticateAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = authenticateResult.Properties;

            properties.StoreTokens(new List<AuthenticationToken>
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = tokenResponse.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = tokenResponse.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.UtcNow
                        .AddSeconds(tokenResponse.ExpiresIn)
                        .ToString("o")
                }
            });

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                authenticateResult.Principal!,
                properties);

            return true;
        }
    }
}
