using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Review : BaseModel
    {
        // This line fetches all reviews that are all critic rated. If userRating is null and ProfessionalRating has value it mens it is critic rating
        // var criticReviews context.Reviews.Where(x => !x.UserRating == null).ToArray();

        // var criticReviews context.Reviews.Where(x => x.IsCriticRated).ToArray();
        // var averageRating = criticReviews.Sum(x => x.isCriticRated) / criticReviews.Count();

        // public double ProfessionalRating { get; set; }

        // public double UserRating { get; set; }

        public double Rating { get; set; }

        public bool IsCriticRated { get; set; }

        public string? Text { get; set; }

        // var movieIdParameter = 123;
        // var movieReviews = context.Movies.Select(x => x.Reviews).Where(x => x.MovieId == movieIdParameter).ToArray();
        public long MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}
