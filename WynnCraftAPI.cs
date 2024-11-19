using WynnCraftAPI4CSharp.API;
using WynnCraftAPI4CSharp.Http;
using WynnCraftAPI4CSharp.Http.Implements;

namespace WynnCraftAPI4CSharp;

public class WynnCraftApi
{
    public static string BaseUrl = "https://api.wynncraft.com/v3/";
    private readonly IWynnHttpClient client;
    private readonly PlayerApi player;
    
    public PlayerApi Player => player;
    public WynnCraftApi(IWynnHttpClient client)
    {
        this.client = client;
        this.player = new PlayerApi(client);
    }
    
    public WynnCraftApi() : this(new DefaultHttpClient()) { }
}