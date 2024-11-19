using System.Text.RegularExpressions;

namespace WynnCraftAPI4CSharp.Model.Character;

public class CharacterArchetype
{
    private static readonly Regex StripColorPattern = new Regex("(?i)&[0-9A-FK-OR]");

    public string name { get; set; }
    public int difficulty { get; set; }
    public int damage { get; set; }
    public int defence { get; set; }
    public int range { get; set; }
    public int speed { get; set; }

    public string GetName()
    {
        return StripColorPattern.Replace(name, "");
    }
    
    public override string ToString()
    {
        return $"CharacterArchetype{{" +
               $"name='{GetName()}', " +
               $"difficulty={difficulty}, " +
               $"damage={damage}, " +
               $"defence={defence}, " +
               $"range={range}, " +
               $"speed={speed}" +
               $"}}";
    }
}