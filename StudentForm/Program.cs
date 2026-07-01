    using Microsoft.EntityFrameworkCore;
    using StudentForm.Infra;
    using StudentForm.Services;
    using StudentForm.Handlers;
    using Serilog;
var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


builder.Host.UseSerilog();
//builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
//builder.Services.AddProblemDetails();


builder.Services.AddControllersWithViews();
    builder.Services.AddScoped<StudentService>();
    



builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));

    var app = builder.Build();
app.UseExceptionHandler("/Home/Error");

app.UseHttpsRedirection();
 
app.UseRouting();
    app.UseStaticFiles();
    app.UseAuthorization();
app.UseSerilogRequestLogging();


app.MapControllerRoute(
        name: "default",
        pattern: "{controller=StudentData}/{action=Index}/{id?}");

    app.Run();