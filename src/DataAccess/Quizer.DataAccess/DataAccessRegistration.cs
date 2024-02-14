using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quizer.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.DataAccess;
public static class DataAccessRegistration
{
    public static IServiceCollection AddDataAccessRegistration(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<QuizerDbContext>();
        return services;
    }
}