using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Bootstrapping
{
    public static class ApiCoreInjection
    {
        public static void AddApiCore(this IServiceCollection services)
        {
            services.AddTransient<IChangeSomethingCommandHandler, ChangeSomethingCommandHandler>();
            services.AddTransient<IChangeSomethingInteractor, ChangeSomethingInteractor>();
        }
    }
}
