using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.13
//dotnet add package Swashbuckle.AspNetCore.SwaggerGen --version 6.2.3
//dotnet add package Swashbuckle.AspNetCore.SwaggerUI --version 6.2.3
namespace API.Model
{
    public class dataDbContext:DbContext
    {
        public dataDbContext()
        {

        }
        public dataDbContext(DbContextOptions<dataDbContext> options) : base(options)
        {

        }
        
        public DbSet<dataprop> dataProp { get; set; }
        
        public DbSet<UserInfo> userInfo  { get; set; }

    }
}
