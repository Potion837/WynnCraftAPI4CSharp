namespace WynnCraftAPI4CSharp.Model.Character;

public class CharacterClassInfo
{
    public string id { get; set; }
    public string name { get; set; }
    public string lore { get; set; }
    public int overallDifficulty { get; set; }
    public Dictionary<string, CharacterArchetype> archetypes { get; set; }

    public override string ToString()
    {
        return $"CharacterClassInfo{{" +
               $"id='{id}', " +
               $"name='{name}', " +
               $"lore='{lore}', " +
               $"overallDifficulty={overallDifficulty}, " +
               $"archetypes={string.Join(", ", archetypes ?? new())}" +
               $"}}";
    }
}