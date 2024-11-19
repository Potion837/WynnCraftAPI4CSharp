using System.Text.Json;
using WynnCraftAPI4CSharp.Json;

namespace WynnCraftAPI4CSharp.Utils;

public class Utilities
{
    public static readonly JsonSerializerOptions Gson = new()
    {
        Converters =
        {
            new CoordinateSearchResultMapAdapter(),
            new PlayerSearchResultMapAdapter(),
            // new GuildSearchResultMapAdapter(),
            // new GuildMemberMapAdapter(),
            new CharacterClassAdapter(),
            new ColorTypeAdapter(),
            new GUidTypeAdapter()
            // new InstantTypeAdapter()
        }
    };
}