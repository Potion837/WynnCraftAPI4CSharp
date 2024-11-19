using System.Text.Json;
using WynnCraftAPI4CSharp.Http;
using WynnCraftAPI4CSharp.Model.Player.Character;
using WynnCraftAPI4CSharp.Selection.Choice.Implements;
using WynnCraftAPI4CSharp.Selection.Choice.Model;
using WynnCraftAPI4CSharp.Utils;

namespace WynnCraftAPI4CSharp.Selection.Player;

public class PlayerCharacterSelection : PlayerChoices
{
    private readonly PlayerCharacter? character;

    public PlayerCharacterSelection(PlayerCharacter? character, Dictionary<Guid, PlayerChoice>? choices)
        : base(choices)
    {
        this.character = character;
    }

    public PlayerCharacter GetCharacter()
    {
        return character;
    }

    public static PlayerCharacterSelection FromResponse(WynnCraftHttpResponse response)
    {
        if (StatusCode.MultipleChoices.Is(response.StatusCode))
        {
            return new PlayerCharacterSelection(
                null,
                JsonSerializer.Deserialize<Dictionary<Guid, PlayerChoice>>(response.Body, Utilities.Gson)
            );
        }
        else
        {
            return new PlayerCharacterSelection(
                JsonSerializer.Deserialize<PlayerCharacter>(response.Body, Utilities.Gson),
                null
            );
        }
    }

    public override string ToString()
    {
        return $"PlayerCharacterSelection{{character={this.character}}} " + base.ToString();
    }
}