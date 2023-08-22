using Microsoft.Extensions.DependencyInjection;
using PizzeriaImpulsMVC.Application.Interfaces;
using PizzeriaImpulsMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaImpulsMVC.Application
{
    public static class DependencyIncjection
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services.AddTransient<IAdditionService, AdditionService>();
            services.AddTransient<IComponentService, ComponentService>();
            services.AddTransient<IDrinkService, DrinkService>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddTransient<IUserManagmentService, UserManagmentService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
