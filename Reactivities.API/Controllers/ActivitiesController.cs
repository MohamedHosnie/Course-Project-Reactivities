using Microsoft.AspNetCore.Mvc;
using Reactivities.Application.Activities;
using Reactivities.Domain.Activities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reactivities.API.Controllers
{
	public class ActivitiesController : BaseApiController
	{
		[HttpGet]
		public async Task <ActionResult<List<Activity>>> GetAll() {
			return await Mediator.Send(new List.Query());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Activity>> Get(Guid id) {
			return await Mediator.Send(new Details.Query { Id = id });
		}

		[HttpPost]
		public async Task<IActionResult> Create(Activity activity) {
			return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Edit(Guid id, Activity activity) {
			activity.Id = id;
			return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id) {
			return Ok(await Mediator.Send(new Delete.Command { Id = id }));
		}
	}
}
