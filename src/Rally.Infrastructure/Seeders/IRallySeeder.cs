using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Infrastructure.Seeders
{
    public interface IRallySeeder
    {
        Task SeedAsync();
    }
}
