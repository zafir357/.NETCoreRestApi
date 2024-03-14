using System;
using Microsoft.Win32;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Services.MapperConfig;

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
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        
	}
}

