using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tmdb.Data.Models
{
    public class SavedMovie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Year { get; set; }

        public string ImageUrl { get; set; }

        public string Overview { get; set; }
    }
}
