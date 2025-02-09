using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews(); // Add this to support MVC views

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Enable static file serving (for index.html or other static assets)
app.UseStaticFiles(); // This should come after routing

app.UseRouting();

// Ensure that the routing is done before static files
app.UseAuthorization();

// Modify the default route pattern to include /index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.MapStaticAssets();

app.Run();
