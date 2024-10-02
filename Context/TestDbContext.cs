using Microsoft.EntityFrameworkCore;
using WebAplicacion.Model;

namespace WebAplicacion.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Buys> Shopping { get; set; }
        public DbSet<Inventory_purchase> purchasing_inventory { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Maintenance_History> Maintenance_sotories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory_Orders> Inventories_Orders { get; set; }
        public DbSet<Services_Orders> Services_Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Services> Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EntityConfiguration para user
            var user = modelBuilder.Entity<User>();
            //Nombre de a tabla / propiedades de los campos 
            user.ToTable("User");
            user.HasKey(u => u.Id);
            user.Property(u => u.Name).HasColumnType("varchar(148)").IsRequired();
            user.Property(u => u.LastName).HasColumnType("varchar(100)");
            user.Property(u => u.Email).HasColumnType("varchar(50)").IsRequired();
            user.Property(u => u.Password);
            user.Property(u => u.PhoneNumber);
            user.Property(u => u.UserName);
            user.Property(u => u.date);
            
            

            var client = modelBuilder.Entity<Client>();

            
            modelBuilder.Entity<Cities>().HasKey(u => u.Id);
            modelBuilder.Entity<Buys>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventory_purchase>().HasKey(u => u.Id);
            modelBuilder.Entity<Employee>().HasKey(u => u.Id);
            modelBuilder.Entity<Maintenance_History>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventory>().HasKey(u => u.Id);
            modelBuilder.Entity<Order>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventory_Orders>().HasKey(u => u.Id);
            modelBuilder.Entity<Services_Orders>().HasKey(u => u.Id);
            modelBuilder.Entity<Payments>().HasKey(u => u.Id);
            modelBuilder.Entity<Suppliers>().HasKey(u => u.Id);
            modelBuilder.Entity<Services>().HasKey(u => u.Id);



        }
    }
}
