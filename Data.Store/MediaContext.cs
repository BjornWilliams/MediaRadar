using Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Data.Store
{
    public class MediaContext : DbContext
    {
        public MediaContext(): base("name=DbCon")
        {
            Database.SetInitializer<MediaContext>(null);
        }

        public static MediaContext Create() => new MediaContext();

        public virtual DbSet<PublicationAdActivity> Publications { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
