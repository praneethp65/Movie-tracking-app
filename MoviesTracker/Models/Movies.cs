using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postgrest.Attributes;
using Postgrest.Models;

namespace MoviesTracker.Models
{
    [Postgrest.Attributes.Table("movies")]
    public class Movie : BaseModel
    {
        [Postgrest.Attributes.PrimaryKey("id", false)]
        public int Id { get; set; }

        [Postgrest.Attributes.Column("title")]
        public string Title { get; set; }

        [Postgrest.Attributes.Column("director")]
        public string Director { get; set; }

        [Postgrest.Attributes.Column("image_url")]
        public string ImageUrl { get; set; }

        [Postgrest.Attributes.Column("created_at", ignoreOnInsert: true)]
        public DateTime CreatedAt { get; set; }

        [Postgrest.Attributes.Column("is_finished")]
        public bool IsFinished { get; set; }

        [Postgrest.Attributes.Column("release_date")]
        public DateTime ReleaseDate { get; set; }
    }
}
