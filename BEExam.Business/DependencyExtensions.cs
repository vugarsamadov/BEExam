using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEExam.Business.Servies;
using BEExam.Business.Servies.Abstract;
using BEExam.Core.Entities;
using Microsoft.Extensions.DependencyInjection;



namespace BEExam.Business
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {

            services.AddAutoMapper(options=>
            {
                options.AddMaps(typeof(LatestNewsServices).Assembly);            
            });


            services.AddScoped<ILatestNewsService, LatestNewsServices>();

            return services;
        }
    }
}
