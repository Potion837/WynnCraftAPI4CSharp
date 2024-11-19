﻿using WynnCraftAPI4CSharp.Http;
using WynnCraftAPI4CSharp.Model.Character;
using WynnCraftAPI4CSharp.Model.Player;
using WynnCraftAPI4CSharp.Model.Player.Abilities;
using WynnCraftAPI4CSharp.Model.Player.Character;
using WynnCraftAPI4CSharp.Selection.Player;

namespace WynnCraftAPI4CSharp.API;

public class PlayerApi : API
    {
        public PlayerApi(IWynnHttpClient client) : base(client)
        {
        }

        public async Task<Player?> GetPlayer(Guid playerId)
        {
            
            return await GetPlayer(playerId, true);
        }

        public async Task<Player?> GetPlayer(Guid playerId, bool fullResult)
        {
            return (await GetPlayer(playerId.ToString(), fullResult)).GetPlayer();
        }

        public async Task<PlayerSelection?> GetPlayer(string username)
        {
            return await GetPlayer(username, true);
        }

        public async Task<PlayerSelection?> GetPlayer(string username, bool fullResult)
        {
            var response = await GetResponse("player/" + username,
                fullResult ? HttpQueryParams.Create().Add("fullResult") : null);
            // Console.WriteLine(response.Body);
            return PlayerSelection.FromResponse(response);
        }

        public async Task<IDictionary<Guid, CharacterEntry>?> GetPlayerCharacters(Guid playerId)
        {
            var characters = await GetPlayerCharacters(playerId.ToString());
            return characters.GetCharacters();
        }

        public async Task<PlayerCharacterListSelection> GetPlayerCharacters(string username)
        {
            var response = await GetResponse("player/" + username + "/characters", null);
            return PlayerCharacterListSelection.FromResponse(
                response
            );
        }

        public async Task<PlayerCharacter> GetPlayerCharacter(Guid playerId, Guid characterId)
        {
            return (await GetPlayerCharacter(playerId.ToString(), characterId)).GetCharacter();
        }

        public async Task<PlayerCharacterSelection> GetPlayerCharacter(string username, Guid characterId)
        {
            return PlayerCharacterSelection.FromResponse( await
                GetResponse("player/" + username + "/characters/" + characterId.ToString(), null)
            );
        }

        public async Task<PlayerAbilities?> GetPlayerAbilities(Guid playerId, Guid characterId)
        {
            var playerAbilities = await GetPlayerAbilities(playerId.ToString(), characterId);
            return playerAbilities.GetAbilities();
        }

        public async Task<PlayerAbilitiesSelection> GetPlayerAbilities(string username, Guid characterId)
        {
            var response = await GetResponse("player/" + username + "/characters/" + characterId, null);
            return PlayerAbilitiesSelection.FromResponse(
                response
            );
        }
}