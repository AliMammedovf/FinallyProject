using FinalProject.Core.Models;
using FinalProject.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace FinalProject.Data.DAL;

public class AppDbContext:IdentityDbContext
{
    public AppDbContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Size> Sizes { get; set; }

    public DbSet<ProductSize> ProductSizes { get; set; }

    public DbSet<Flavour> Flavours { get; set; }

    public DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<AppUser> Users { get; set; }

	public DbSet<BasketItem> BasketItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Table> Tables { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Slider> Sliders { get; set; }

    public DbSet<AboutSlider> AboutSliders { get; set; }

    public DbSet<PizzaMenyu> Pizzas {  get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<SetMenyuHeader> SetMenyuHeaders { get; set; }

    public DbSet<KomboMenyu> KomboMenyus { get; set; }

    public DbSet<AboutInfo> Info {  get; set; }



	protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ProductConfugration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfugration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(FlavourConfugration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(SizeConfugration).Assembly);
		builder.ApplyConfigurationsFromAssembly(typeof(ReservationConfugration).Assembly);
		builder.ApplyConfigurationsFromAssembly(typeof(TableConfiguration).Assembly);
		builder.ApplyConfigurationsFromAssembly(typeof(SliderConfugration).Assembly);
		builder.ApplyConfigurationsFromAssembly(typeof(AboutSliderConfiguration).Assembly);
		builder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
		builder.ApplyConfigurationsFromAssembly(typeof(SetMenyuHeadersConfiguration).Assembly);
		builder.ApplyConfigurationsFromAssembly(typeof(AboutInfoConfiguration).Assembly);
		base.OnModelCreating(builder);
        
    }

    
}
