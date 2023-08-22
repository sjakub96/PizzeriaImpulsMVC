using Microsoft.Extensions.DependencyInjection;
using PizzeriaImpulsMVC.Domain.Interfaces;
using PizzeriaImpulsMVC.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Infrastructure
{
    public static class DependencyIncjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAdditionRepository, AdditionRepository>();
            services.AddTransient<IComponentRepository, ComponentRepository>();
            services.AddTransient<IDrinkRepository, DrinkRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IUserManagmentRepository, UserManagmentRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();

            return services;
        }
    }
}
