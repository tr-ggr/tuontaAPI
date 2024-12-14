namespace tuontaAPI.DTO
{
    public class MatchStatusDto
    {
        public int user1Id { get; set; }
        public int user2Id { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;
    }
}
