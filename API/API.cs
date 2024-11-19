﻿using System.Text.Json;
using WynnCraftAPI4CSharp.Http;
using WynnCraftAPI4CSharp.Utils;

namespace WynnCraftAPI4CSharp.API;

public class API
{
    private readonly IWynnHttpClient _client;

    public API(IWynnHttpClient client)
    {
        _client = client;
    }

    public async Task<T> Post<T>(string request, string payload, HttpQueryParams? @params = null)
    {
        var response = await GetResponse(request, payload, @params);
        return JsonSerializer.Deserialize<T>(response.Body);
    }

    public async Task<T> Post<T>(string request, string payload)
    {
        return await Post<T>(request, payload, null);
    }

    public async Task<object> Post(string request, string payload, Type type, HttpQueryParams? @params = null)
    {
        var response = await GetResponse(request, payload, @params);
        return JsonSerializer.Deserialize(response.Body, type);
    }

    public async Task<object> Post(string request, string payload, Type type)
    {
        return await Post(request, payload, type, null);
    }

    public async Task<T> Get<T>(string request, HttpQueryParams? @params = null)
    {
        var response = await GetResponse(request, @params);
        return JsonSerializer.Deserialize<T>(response.Body);
    }

    public async Task<T> Get<T>(string request)
    {
        return await Get<T>(request, null);
    }

    public async Task<object> Get(string request, Type type, HttpQueryParams? @params = null)
    {
        var response = await GetResponse(request, @params);
        return JsonSerializer.Deserialize(response.Body, type);
    }

    public async Task<object> Get(string request, Type type)
    {
        return await Get(request, type, null);
    }

    public async Task<WynnCraftHttpResponse> GetResponse(string request, string payload, HttpQueryParams? @params)
    {
        var url = WynnCraftApi.BaseUrl + request;

        if (@params != null) url = @params.GetAsQueryString(url);

        var response = await _client.MakePostRequest(url, payload);

        ValidateResponse(response);

        return response;
    }

    public async Task<WynnCraftHttpResponse> GetResponse(string request, HttpQueryParams? @params)
    {
        var url = WynnCraftApi.BaseUrl + request;

        if (@params != null) url = @params.GetAsQueryString(url);

        var response = await _client.MakeGetRequest(url);

        ValidateResponse(response);

        return response;
    }

    private void ValidateResponse(WynnCraftHttpResponse response)
    {
        var statusCode = response.StatusCode;

        if (statusCode == (int)StatusCode.Ok || statusCode == (int)StatusCode.MultipleChoices) return;

        var responseBody = response.Body;

        try
        {
            var obj = JsonSerializer.Deserialize<JsonElement>(responseBody);
            if (obj.TryGetProperty("Error", out var err)) throw new WynnCraftException(statusCode, err.GetString());
        }
        catch (JsonException)
        {
            throw new WynnCraftException(statusCode, $"An unknown error has occurred. - {responseBody}");
        }
    }
}