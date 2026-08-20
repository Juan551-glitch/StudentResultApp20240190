using Microsoft.EntityFrameworkCore;
using StudentResultApp.Components;
using StudentResultApp.Data;
using StudentResultApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ModuleService>();

var connectionString = new[]
{
    builder.Configuration.GetConnectionString("DefaultConnection"),
    builder.Configuration["DefaultConnection"],
    builder.Configuration.GetConnectionString("StudentResultsDB")
}.FirstOrDefault(value => !string.IsNullOrWhiteSpace(value));

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
