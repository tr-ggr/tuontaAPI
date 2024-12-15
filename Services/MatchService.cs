using tuontaAPI.DTO;
using tuontaAPI.Repositories;
using tuontaAPI.Models;
using tuontaAPI.Interfaces;

namespace tuontaAPI.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }


        public List<MatchedItemDto> GetMatches()
        {
            List<MatchedItemDto> matches = new List<MatchedItemDto>();
            foreach (var match in _matchRepository.GetMatches())
            {
                matches.Add(new MatchedItemDto()
                {
                    Id = match.Id,
                    MatchStatus1Id = match.MatchStatus1Id,
                    MatchStatus2Id = match.MatchStatus2Id,
                    date_matched = match.date_matched

                });
            }

            return matches;
        }

        public List<MatchedItemDto> GetAllMatchedItemByUserId(int userId)
        {
            List<MatchedItemDto> matches = new List<MatchedItemDto>();
            foreach (var match in _matchRepository.GetMatchedItemsByUserId(userId))
            {
                matches.Add(new MatchedItemDto()
                {
                    Id = match.Id,
                    MatchStatus1Id = match.MatchStatus1Id,
                    MatchStatus2Id = match.MatchStatus2Id,
                    isActive = match.isActive,
                    date_matched = match.date_matched
                });
            }
            return matches;
        }

        public List<MatchStatusDto> GetAllMatchStatusByUserId(int userId)
        {
            List<MatchStatusDto> matches = new List<MatchStatusDto>();
            foreach (var match in _matchRepository.GetAllMatchStatus())
            {
                if (match.user1Id == userId)
                {
                    matches.Add(new MatchStatusDto()
                    {
                        user1Id = match.user1Id,
                        user2Id = match.user2Id,
                        date_created = match.date_created
                    });
                }
            }
            return matches;
        }

        public List<MatchStatusDto> GetAllMatchStatus()
        {
            List<MatchStatusDto> matches = new List<MatchStatusDto>();
            foreach (var match in _matchRepository.GetAllMatchStatus())
            {
                matches.Add(new MatchStatusDto()
                {
                    user1Id = match.user1Id,
                    user2Id = match.user2Id,
                    date_created = match.date_created
                });
            }

            return matches;
        }

        public bool CreateMatchStatus(MatchStatusDto matchStatus)
        {


            int newId = _matchRepository.GetAllMatchStatus().Count + 1;

            MatchStatus match = new MatchStatus()
            {
                user1Id = matchStatus.user1Id,
                user2Id = matchStatus.user2Id,
                date_created = matchStatus.date_created
            };

            return _matchRepository.CreateMatchStatus(match);

        }

        public ChatDto UpdateMatchStatus(int id, ChatItemDto chatItemDto)
        {
            var chatItem = new ChatItem()
            {
                ChatId = chatItemDto.ChatId.HasValue ? chatItemDto.ChatId.Value : 0,
                SenderId = chatItemDto.SenderId,
                Message = chatItemDto.Message,
                Timestamp = chatItemDto.Timestamp
            };

            var chat = _matchRepository.UpdateMatchStatus(id, chatItem);

            if (chat == null)
            {
                return null;
            }

            return new ChatDto()
            {
                Id = chat.Id,
                User1Id = chat.User1Id,
                User2Id = chat.User2Id,
                CreatedAt = chat.CreatedAt,
                ChatItems = chat.ChatItems.Select(item => new ChatItemDto
                {
                    ChatId = item.ChatId,
                    SenderId = item.SenderId,
                    Message = item.Message,
                    Timestamp = item.Timestamp
                }).ToList()
            };
        }



        public List<ProfileDto> GetUsersOfMatchedItem(int id)
        {
            var profiles = _matchRepository.GetUsersOfMatchedItem(id);
            return profiles.Select(profile => new ProfileDto
            {
                Id = profile.Id,
                Username = profile.Username,
                Email = profile.Email,
                Birthday = profile.Birthday,
                Gender = profile.Gender,
                Bio = profile.Bio,
                School = profile.School,
                Course = profile.Course,
                Distance = profile.Distance,
                Hobbies = profile.Hobbies,
                ProfileImages = profile.ProfileImages
            }).ToList();
        }




    }
}
