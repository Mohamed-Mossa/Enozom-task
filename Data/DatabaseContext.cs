namespace Enozom_task.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions <DatabaseContext> options) : base(options)
        {

        }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Id = 1, name = "Sheraton" },
                new Hotel { Id = 2, name = "Helnan" },
                new Hotel { Id = 3, name = "Tolip" }

            );

        

            // Seed Prices
            modelBuilder.Entity<Price>().HasData(
                new Price { Id = 1, HotelID = 1, Room = "Double Room Sea View",Cost = 200 },
                new Price { Id = 2, HotelID = 1, Room = "SingleRoom Sea View", Cost = 150 },
                new Price { Id = 3, HotelID = 1, Room = "Double Room City View", Cost = 170 },
                new Price { Id = 4, HotelID = 1, Room = "Single Room City View " ,Cost = 120 },
                new Price { Id = 5, HotelID = 2, Room = "Double Room Garden View", Cost = 100 },
                new Price { Id = 6, HotelID = 2, Room = "Single Room Garden View",Cost = 90 },
                new Price { Id = 7, HotelID = 2, Room = "Double Room Pool View", Cost = 120 },
                new Price { Id = 8, HotelID = 2, Room = "Single Room Pool View", Cost = 110 },
                new Price { Id = 9, HotelID = 3, Room = "Double Room Standard", Cost = 80 },
                new Price { Id = 10, HotelID = 3, Room = "Single Room Standard", Cost = 70 },
                new Price { Id = 11, HotelID = 3, Room = "Double Room Deluxe", Cost = 100 },
                new Price { Id = 12, HotelID = 3, Room = "Single Room Deluxe" , Cost = 95 }
                // Add more prices if needed
            );
        }
    }
}
