using Microsoft.EntityFrameworkCore;
using snapShot.API.Models.Domain;

namespace snapShot.API.Data
{
    public class SnapShotDbContext: DbContext
    {
        public SnapShotDbContext(DbContextOptions<SnapShotDbContext> dbContextOptions ):base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("11093fed-ca90-4277-8789-5189e68630cb"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("726fad50-d3a6-44c7-a68e-f7b97eeece65"),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("f0428b14-5737-4926-92cb-ed2a6b852aa9"),
                    Name="Hard"
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("68f40740-4eca-4a45-9154-1c55cefebcb8"),
                    Code="AKL",
                    Name="Auckland Region",
                    RegionImageUrl="https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=600"
                },
                new Region()
                {
                    Id=Guid.Parse("4147dfa0-c90b-4918-ab98-5c463eabb66e"),
                    Code="WLG",
                    Name="Wellington Region",
                    RegionImageUrl="https://images.pexels.com/photos/8379417/pexels-photo-8379417.jpeg?auto=compress&cs=tinysrgb&w=600"
                },                
                new Region()
                {
                    Id=Guid.Parse("e45935cc-ae2b-483b-bce3-6e95ff9c6077"),
                    Code="STL",
                    Name="Scotland Region",
                    RegionImageUrl=null
                }, 
                new Region()
                {
                    Id=Guid.Parse("0b102c44-c7b5-4bfb-bf7f-d046b2907f5f"),
                    Code="NSN",
                    Name="Nelson Region",
                    RegionImageUrl=null
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
