using Assignment1AlbyPROG3176.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1AlbyPROG3176.Data
{
	public class ExpenseDbContext : DbContext
	{
		public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
		{
		}
		public DbSet<Expense> Expenses { get; set; }
	}
}
