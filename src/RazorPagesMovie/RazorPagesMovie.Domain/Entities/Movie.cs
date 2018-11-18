using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using LinqKit;

namespace RazorPagesMovie.Domain.Entities
{
    public class Movie
    {
        public int ID { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }

    public class MovieCondition
    {
        public string Title_like { get; set; }
        public DateTime? ReleaseDate_le { get; set; }
        public DateTime? ReleaseDate_ge { get; set; }

        public Expression<Func<Movie, bool>> CreatePredicate()
        {
            var predicate = PredicateBuilder.True<Movie>();

            if (!string.IsNullOrEmpty(Title_like))
            {
                predicate = predicate.And(expr2 => expr2.Title.Contains(Title_like));
            }

            if (ReleaseDate_ge.HasValue)
            {
                predicate = predicate.And(expr2 => expr2.ReleaseDate >= ReleaseDate_ge);
            }

            if (ReleaseDate_le.HasValue)
            {
                predicate = predicate.And(expr2 => expr2.ReleaseDate <= ReleaseDate_le);
            }

            return predicate;

        }
    }

}
