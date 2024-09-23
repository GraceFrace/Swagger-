using Microsoft.AspNetCore.Mvc;
using HTTPswagerTEST.Models;
using HTTPswagerTEST;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HTTPswagerTEST.Controllers
{
	[ApiController]
	//[Produces("application/json")]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly UsersContext _context;


		public UsersController(UsersContext context)
		{
			_context = context;

			if (_context.Users.Count() == 0 )
			{
				_context.Users.Add(new Users { Id = 1, Name = "Denis", Mail = "denis@gmail.com" });
				_context.SaveChanges();
			}
		}

		/// <summary>
		/// Выводит всех пользователей
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult<List<Users>> GetAll()
		{
			return _context.Users.ToList();
		}

		/// <summary>
		/// Создаём нового пользователя
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult<Users> Create(Users item)
		{
			_context.Users.Add(item);
			_context.SaveChanges();

			return Ok("Готово");
		}

		/// <summary>
		/// Меняем данные пользователя
		/// </summary>
		/// <param name="id"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public IActionResult Update(int id, Users item)
		{
			if (item == null || item.Id != id)
				return BadRequest();

			var tobuy = _context.Users.Find(id);

			if (tobuy == null)
				return NotFound();

			tobuy.Name = item.Name;
			tobuy.Mail = item.Mail;

			_context.Users.Update(tobuy);
			_context.SaveChanges();

			return Ok($"Готово!");
		}

		/// <summary>
		/// Меняем Имя
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpPatch("{name}")]
		public IActionResult Patch(int id, string name)
		{
			var tobuy = _context.Users.Find(id);
			if (tobuy == null)
				return NotFound();

			tobuy.Name = name;
			_context.Users.Update(tobuy);
			_context.SaveChanges();

			return Ok($"Имя успешно изменено на: {name}!");
		}

		/// <summary>
		/// Удалить пользователя!
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var tobuy = _context.Users.Find(id);

			if (tobuy == null)
				return NotFound();

			_context.Users.Remove(tobuy);
			_context.SaveChanges();

			return Ok($"Человек успешно удалён");
		}

	}
}
