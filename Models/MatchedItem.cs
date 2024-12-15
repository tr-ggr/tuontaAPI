using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tuontaAPI.Models
{
    public class MatchedItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MatchStatus1Id { get; set; }
        public int MatchStatus2Id { get; set; }

        public bool isActive { get; set; } = true;


        public DateTime date_matched {  get; set; } = DateTime.Now;
    }
}
