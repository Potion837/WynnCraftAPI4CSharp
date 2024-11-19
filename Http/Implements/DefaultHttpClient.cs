﻿using System.Text;

namespace WynnCraftAPI4CSharp.Http.Implements;

public class DefaultHttpClient : IWynnHttpClient
{
    private readonly HttpClient _httpClient = new()
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    public void Shutdown()
    {
        _httpClient.Dispose();
    }

    public async Task<WynnCraftHttpResponse> MakeGetRequest(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", IWynnHttpClient.DefaultUserAgent);
        return await GetResponseAsync(request);
    }

    public async Task<WynnCraftHttpResponse> MakePostRequest(string url, string payload)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
        request.Headers.Add("User-Agent", IWynnHttpClient.DefaultUserAgent);
        return await GetResponseAsync(request);
    }

    private async Task<WynnCraftHttpResponse> GetResponseAsync(HttpRequestMessage request)
    {
        try
        {
            using var response = await _httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            var rateLimit = CreateRateLimit(response);
            return new WynnCraftHttpResponse((int)response.StatusCode, responseBody, rateLimit);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error during HTTP request", ex);
        }
    }

    private RateLimit CreateRateLimit(HttpResponseMessage response)
    {
        var headers = response.Headers;
        return new RateLimit(
            int.Parse(headers.GetValues("RateLimit-Remaining").FirstOrDefault() ?? "0"),
            int.Parse(headers.GetValues("RateLimit-Reset").FirstOrDefault() ?? "0"),
            int.Parse(headers.GetValues("RateLimit-Limit").FirstOrDefault() ?? "0")
        );
    }
}