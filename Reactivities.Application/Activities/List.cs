﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Reactivities.Domain.Activities;
using Reactivities.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reactivities.Application.Activities
{
	public class List
	{
		public class Query : IRequest<List<Activity>> {}

		public class Handler : IRequestHandler<Query, List<Activity>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
			{
				return await _context.Activities.ToListAsync();
			}
		}
	}
}
