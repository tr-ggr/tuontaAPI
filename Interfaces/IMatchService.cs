﻿using tuontaAPI.DTO;

namespace tuontaAPI.Interfaces
{
    public interface IMatchService
    {
        List<MatchedItemDto> GetMatches();
        public List<MatchStatusDto> GetAllMatchStatus();
        public List<MatchedItemDto> GetAllMatchedItemByUserId(int userId);
        public List<MatchStatusDto> GetAllMatchStatusByUserId(int userId);

        public bool CreateMatchStatus(MatchStatusDto matchStatus);
        public ChatDto UpdateMatchStatus(int id, ChatItemDto chatItemDto);
        public List<ProfileDto> GetUsersOfMatchedItem(int id);
    }
}



