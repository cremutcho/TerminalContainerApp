using Microsoft.EntityFrameworkCore;
using TerminalContainerApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a MVC
builder.Services.AddControllersWithViews();

// Configura EF Core com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Pega a connection string do appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configuração de ambiente
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TruckEntries}/{action=Index}/{id?}");

// Inicia a aplicação
app.Run();
