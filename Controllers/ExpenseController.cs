using Assignment1AlbyPROG3176.Data;
using Assignment1AlbyPROG3176.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1AlbyPROG3176.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseController : ControllerBase
	{
		private readonly ExpenseDbContext _context;

		public ExpenseController(ExpenseDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetExpenses()
		{
			var expenses = _context.Expenses.ToList();
			return Ok(expenses);
		}

		[HttpGet]
		[Route("{id}")]
		public IActionResult GetExpense(int id)
		{
			var expense = _context.Expenses.Find(id);
			if (expense == null)
			{
				return NotFound();
			}
			return Ok(expense);
		}

		[HttpPost]
		public IActionResult CreateExpense([FromBody] Expense expense)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_context.Expenses.Add(expense);
			_context.SaveChanges();
			return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
		}

		[HttpPut]
		[Route("{id}")]
		public IActionResult UpdateExpense(int id, [FromBody] Expense expense)
		{
			if (id != expense.Id || !ModelState.IsValid)
			{
				return BadRequest();
			}
			var existingExpense = _context.Expenses.Find(id);
			if (existingExpense == null)
			{
				return NotFound();
			}
			existingExpense.Description = expense.Description;
			existingExpense.Amount = expense.Amount;
			existingExpense.DateIncurred = expense.DateIncurred;
			existingExpense.Category = expense.Category;
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete]
		[Route("{id}")]
		public IActionResult DeleteExpense(int id)
		{
			var expense = _context.Expenses.Find(id);
			if (expense == null)
			{
				return NotFound();
			}
			_context.Expenses.Remove(expense);
			_context.SaveChanges();
			return NoContent();
		}		
	}
}
