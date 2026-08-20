using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagment.AggregateRoot.Aggregates;
using UserManagment.AggregateRoot.PasswordHasher;

namespace UserManagment.AggregateRoot.Extentions
{
    public static class AggregatorServiceCollection
    {
        public static IServiceCollection AddAggregator(this IServiceCollection services)
        {
            services.AddScoped<UserRegisterAggregate>();
            services.AddScoped<UserUpdateAggregate>();
            services.AddScoped<PasswordHash>();
            return services;
        }
    }
}
