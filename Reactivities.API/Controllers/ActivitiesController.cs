using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain.Activities;
using Reactivities.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reactivities.API.Controllers
{
	public class ActivitiesController : BaseApiController
	{
		private readonly DataContext _context;

		public ActivitiesController(DataContext context) {
			_context = context;
		}

		[HttpGet]
		public async Task <ActionResult<List<Activity>>> GetAll() {
			return await _context.Activities.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<Activity> Get(Guid id) {
			return await _context.Activities.FindAsync(id);
		}
	}
}
