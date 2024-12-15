namespace tuontaAPI.DTO
{
    public class MatchedItemDto
    {
        public int Id { get; set; }
        public int MatchStatus1Id { get; set; }
        public int MatchStatus2Id { get; set; }
        public bool isActive { get; set; }
        public DateTime date_matched { get; set; } = DateTime.Now;
    }
}
