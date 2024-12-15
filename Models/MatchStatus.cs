using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tuontaAPI.Models
{
    public class MatchStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int user1Id { get; set; }
        public int user2Id { get; set; }
        public bool isActive { get; set; } = true;

        public DateTime date_created { get; set; } = DateTime.Now;
    }
}
