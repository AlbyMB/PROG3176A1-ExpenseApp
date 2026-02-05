using System.ComponentModel.DataAnnotations;

namespace Assignment1AlbyPROG3176.Models
{
	public class Expense
	{
		public int Id { get; set; }
		public string Description { get; set; }
		
		[Required]
		public decimal Amount { get; set; }

		[Required]
		public DateTime DateIncurred { get; set; }
		public string Category { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.Now;
	}
}
