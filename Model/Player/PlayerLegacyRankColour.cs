using System.Drawing;

namespace WynnCraftAPI4CSharp.Model.Player;

public class PlayerLegacyRankColour
{
    public Color Main { get; set; }
    public Color Sub { get; set; }

    public Color GetMain()
    {
        return this.Main;
    }

    public Color GetSub()
    {
        return this.Sub;
    }
    
    public override string ToString()
    {
        return $"PlayerLegacyRankColour{{main={this.Main}, sub={this.Sub}}}";
    }
}