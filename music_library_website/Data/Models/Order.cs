using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace music_library_website.Data.Models
{
	public class Order
    {
        [BindNever]
        public long Id { get; set; }

        [Display(Name = "Имя")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина имени - от 2 до 50 символов")]
		public string Name { get; set; }

		[Display(Name = "Фамилия")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина фамилии - от 2 до 50 символов")]
		public string Surname { get; set; }

		[Display(Name = "Адрес доставки")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина адреса - от 2 до 50 символов")]
		public string Address { get; set; }

		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string EMail {  get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public DateTime OrderTime { get; set; }
		
		[BindNever]
		[JsonIgnore]
		public List<OrderDetail> OrderDetails { get; set; }
	}
}
