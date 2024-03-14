using System;
using AutoMapper;

namespace Services.MapperConfig
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
	}
}

