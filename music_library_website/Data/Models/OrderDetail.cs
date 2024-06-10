using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace music_library_website.Data.Models
{
	public class OrderDetail
    {
        public long Id { get; set; }
        public double Price { get; set; }
        public VinylRecord VinylRecord { get; set; }

		[ForeignKey(nameof(OrderId))]
		public Order Order { get; set; }
		public long OrderId { get; set; }
	}
}