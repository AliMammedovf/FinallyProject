using FinalProject.Business.DTOs.AboutInfoDTOs;
using FinalProject.Business.DTOs.CategoryDTOs;
using FinalProject.Business.DTOs.EmployeeDTOs;
using FinalProject.Business.DTOs.FlavourDTOs;
using FinalProject.Business.DTOs.PizzaMenyuDTOs;
using FinalProject.Business.DTOs.ProductDTOs;
using FinalProject.Business.DTOs.ReservationDTOs;
using FinalProject.Business.DTOs.SetMenyuHeaderDTOs;
using FinalProject.Business.DTOs.SizeDTOs;
using FinalProject.Business.DTOs.SliderDTOs;
using FinalProject.Business.DTOs.TableDTOs;
using FinalProject.Business.Mapping;
using FinalProject.Business.Services.Abstarct;
using FinalProject.Business.Services.Concret;
using FinalProject.Core.Models;
using FinalProject.Core.RepositoryAbstract;
using FinalProject.Data.DAL;
using FinalProject.Data.RepositoryConcret;
using FinalProject.ViewService;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace FinalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining(typeof(ProductCreateDTOValidator));
                x.RegisterValidatorsFromAssemblyContaining(typeof(CategoryCreateDTOValidator));
                x.RegisterValidatorsFromAssemblyContaining(typeof(FlavourCreateDTOValidator));
                x.RegisterValidatorsFromAssemblyContaining(typeof(SizeCreateDTOValidator));
				x.RegisterValidatorsFromAssemblyContaining(typeof(TableCreateDTOValidator));
				x.RegisterValidatorsFromAssemblyContaining(typeof(ReservationCreateDTOValidator));
				x.RegisterValidatorsFromAssemblyContaining(typeof(SliderCreateDTOValidator));
                x.RegisterValidatorsFromAssemblyContaining(typeof(AboutSliderCreateDTOValidator));
                x.RegisterValidatorsFromAssemblyContaining(typeof(PizzaMenyuCreateDTOValidator));
				x.RegisterValidatorsFromAssemblyContaining(typeof(EmployeeCreateDTOValidator));
				x.RegisterValidatorsFromAssemblyContaining(typeof(SetMenyuHeaderCreateDTOValidator));
				x.RegisterValidatorsFromAssemblyContaining(typeof(AboutInfoCreateDTOValidator));
			});
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddDbContext<AppDbContext>(options =>

                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                sqlServerOptions => sqlServerOptions.CommandTimeout(300)));

            

			builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
			{
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;
			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            builder.Services.AddScoped<LayoutService>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, Business.Services.Concret.ProductService>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IFlavourRepository, FlavourRepository>();
            builder.Services.AddScoped<IFlavourService, FlavourService>();

            builder.Services.AddScoped<ISizeRepository, SizeRepository>();
            builder.Services.AddScoped<ISizeService, SizeService>();

            builder.Services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();

            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            builder.Services.AddScoped<IBasketItemService, BasketItemService>();

            builder.Services.AddScoped<ITableRepository, TableRepository>();
            builder.Services.AddScoped<ITableService, TableService>();

            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IReservationService, ReservationService>();

            builder.Services.AddScoped<ISliderRepository, SliderRepository>();
            builder.Services.AddScoped<ISliderService, SliderService>();

            builder.Services.AddScoped<IAboutSliderRepository, AboutSliderRepository>();
            builder.Services.AddScoped<IAboutSliderService, AboutSliderService>();

            builder.Services.AddScoped<IPizzaMenyuRepository, PizzaMenyuRepository>();
            builder.Services.AddScoped<IPizzaMenyuService, PizzaMenyuService>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddScoped<ISetMenyuHeaderService, SetMenyuHeaderService>();
            builder.Services.AddScoped<ISetMenyuHeaderRepository, SetMenyuHeaderRepository>();

            builder.Services.AddScoped<IKomboMenyuRepository, KomboMenyuRepository>();
            builder.Services.AddScoped<IKomboMenyuService, KomboMenyuService>();

            builder.Services.AddScoped<IAboutInfoRepository, AboutInfoRepository>();
            builder.Services.AddScoped<IAboutInfoService, AboutInfoService>();

            builder.Services.AddSession();


			builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

			StripeConfiguration.ApiKey = builder.Configuration["Stripe:Secretkey"];


			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/Home");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseAuthorization();
             app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
