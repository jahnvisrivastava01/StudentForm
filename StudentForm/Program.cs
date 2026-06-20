    using Microsoft.EntityFrameworkCore;
    using StudentForm.Infra;
using StudentForm.Services;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllersWithViews();
    builder.Services.AddScoped<StudentService>();

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

    var app = builder.Build();

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseStaticFiles();
    app.UseAuthorization();


    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=StudentData}/{action=Index}/{id?}");

    app.Run();