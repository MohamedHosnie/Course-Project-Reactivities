using AutoMapper;
using Reactivities.Domain.Activities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactivities.Application.Core
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Activity, Activity>();
		}
	}
}
