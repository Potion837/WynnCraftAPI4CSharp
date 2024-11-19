
using WynnCraftAPI4CSharp.Model.Player.Character;

namespace WynnCraftAPI4CSharp
{
    public class Program
    {
        public async static Task Main(String[] args)
        {
            var player = new WynnCraftApi().Player;
            var playerName = "younkoo_qwq";
            var playerSelection = await player.GetPlayer(playerName);
            var rank = playerSelection?.GetPlayer()?.GetPlayerRank();
            var firstJoinTime = playerSelection?.GetPlayer()?.firstJoin;
            var lastJoinTime = playerSelection?.GetPlayer()?.lastJoin;
            var characters = playerSelection?.GetPlayer()?.characters!;
            foreach (var pair in characters)
            {
                var character = pair.Value;
                var dungeonsInfo = "";
                var questsInfo = "";
                
                if (character.dungeons.list != null)
                {
                    dungeonsInfo += $"地下城探索总数: {character.dungeons.total}\n";
                    Console.WriteLine(character.dungeons.list);
                    foreach (var dungeon in character.dungeons.list) {
                        if (dungeonsInfo.Length <= 5)
                        {
                            dungeonsInfo += $"  * {dungeon}\n";
                        } else
                        {
                            dungeonsInfo += "And more...\n";
                            break;
                        }
                    }
                }
                
                if (character.quests != null)
                {
                    questsInfo += $"已完成的任务 (总数: {character.quests.Length})\n";
                    foreach (var quest in character.quests) {
                        if (questsInfo.Length <= 5)
                        {
                            questsInfo += "  * $quest\n";
                        } else
                        {
                            questsInfo += "And more...\n";
                            break;
                        }
                    }
                }

                var uuid = playerSelection?.GetPlayer()?.characters.ToList().Find(pair => playerSelection?.GetPlayer()?.characters[pair.Key] == character).Key.ToString();
                
                String text = "档案信息:\n" +
                $"档案名称: {character.nickName ?? playerName}\n" +
                $"档案 UUID: {uuid}\n" +
                $"职业: {character.type}\n" +
                $"等级: {character.level}\n" +
                $"在线时长: {character.playtime} 小时\n" +
                $"登入次数: {character.logins}\n" +
                $"死亡次数: {character.deaths}\n" +
                $"击杀生物数: {character.mobsKilled}\n" +
                $"移动距离: {character.blocksWalked}b\n" +
                $"已探索数量: {character.discoveries}\n" +
                $"找到的箱子: {character.chestsFound}\n" +
                "技能点信息:\n" +
                $"  * Strength: {character.skillPoints.strength}\n" +
                $"  * Dexterity: {character.skillPoints.dexterity}\n" +
                $"  * Intelligence: {character.skillPoints.intelligence}\n" +
                $"  * Defense: {character.skillPoints.defence}\n" +
                $"  * Agility: {character.skillPoints.agility}\n" +
                $"PVP: 击杀: {character.pvp.kills}, 死亡: {character.pvp.deaths}\n" +
                $"专业等级:\n" +
                $"  * Fishing: {character.professions.fishing.level}\n" +
                $"  * Woodcutting: {character.professions.woodcutting.level}\n" +
                $"  * Mining: {character.professions.mining.level}\n" +
                $"  * Farming: {character.professions.farming.level}\n" +
                $"  * Scribing: {character.professions.scribing.level}\n" +
                $"  * Jeweling: {character.professions.jeweling.level}\n" +
                $"  * Alchemism: {character.professions.alchemism.level}\n" +
                $"  * Cooking: {character.professions.cooking.level}\n" +
                $"  * Weaponsmithing: {character.professions.weaponsmithing.level}\n" +
                $"  * Tailoring: {character.professions.tailoring.level}\n" +
                $"  * Woodworking: {character.professions.woodworking.level}\n" +
                $"  * Armouring: {character.professions.armouring.level}\n" +
                dungeonsInfo +
                questsInfo;
                Console.Write(text);
        }
            // Console.WriteLine(text);
        }
    }
}