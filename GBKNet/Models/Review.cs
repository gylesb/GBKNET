using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBKNet.Models
{
	[Table("Reviews")]
	public class Review
	{
		[Key]
		public int ReviewId { get; set; }
		public int ProductId { get; set; }
		public string ReviewAuthor { get; set; }
		public string ReviewContentBody { get; set; }
        public int ReviewRating { get; set; }
	}
}