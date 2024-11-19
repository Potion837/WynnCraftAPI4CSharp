namespace WynnCraftAPI4CSharp.Model.Character;

public class CharacterClass
{
    public CharacterType type { get; set; }
    public CharacterType donorType { get; set; }
    public int overallDifficulty { get; set; }

    public override string ToString()
    {
        return $"CharacterClass{{" +
               $"type={type}, " +
               $"donorType={donorType}, " +
               $"overallDifficulty={overallDifficulty}" +
               $"}}";
    }
}