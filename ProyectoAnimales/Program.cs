using Microsoft.EntityFrameworkCore;
using ProyectoAnimales.Models;

var builder = WebApplication.CreateBuilder(args);

// 1) Registro del DbContext con la cadena de conexión "conexion" de appsettings.json
builder.Services.AddDbContext<ProyectoAnimalesContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("conexion")
    )
);

// 2) Añade los servicios de MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3) Configura el pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta por defecto de MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
