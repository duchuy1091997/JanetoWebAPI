using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class ApiDBContext:DbContext
    {
        public ApiDBContext() : base("JanetoEntities")
        {

        }
        static ApiDBContext()
        {
            Database.SetInitializer<ApiDBContext>(new IdentityDBInit());
        }
        public static ApiDBContext Create()
        {
            return new ApiDBContext();
        }
        public DbSet<Class> Class { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

    internal class IdentityDBInit : DropCreateDatabaseIfModelChanges<ApiDBContext>
    {
        public void Seed(ApiDBContext context)
        {
            PerformInit();
            base.Seed(context);
        }

        private void PerformInit()
        {
        }
    }
}
