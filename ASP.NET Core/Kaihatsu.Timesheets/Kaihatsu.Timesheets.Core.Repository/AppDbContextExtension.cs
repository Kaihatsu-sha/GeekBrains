using Kaihatsu.Timesheets.Core.Abstraction.Data;
using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Kaihatsu.Timesheets.Core.Repository.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.Core.Repository
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection AddEfContext(this IServiceCollection collection)
        {
            return collection.AddDbContext<AppDbContext>();
        }
    }
}
