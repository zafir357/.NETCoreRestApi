using System;
using Microsoft.Win32;
using AutoMapper;
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Impl;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
	public static class RegisterMapper
	{

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
            {

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        
	}
}

