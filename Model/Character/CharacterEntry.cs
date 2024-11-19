namespace WynnCraftAPI4CSharp.Model.Character;

public class CharacterEntry
{
    public string type { get; set; }
    public string nickname { get; set; }
    public int level { get; set; }
    public long xp { get; set; }
    public int xpPercent { get; set; }
    public int totalLevel { get; set; }
    public string[] gamemode { get; set; }
    public Dictionary<string, object> meta { get; set; }

    public override string ToString()
    {
        return $"CharacterEntry{{" +
               $"gamemode={string.Join(", ", gamemode ?? Array.Empty<string>())}, " +
               $"type='{type}', " +
               $"nickname='{nickname}', " +
               $"level={level}, " +
               $"xp={xp}, " +
               $"xpPercent={xpPercent}, " +
               $"totalLevel={totalLevel}, " +
               $"meta={string.Join(", ", meta ?? new())}" +
               $"}}";
    }
}