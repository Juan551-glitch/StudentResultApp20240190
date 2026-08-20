using Microsoft.EntityFrameworkCore;
using StudentResultApp.Components;
using StudentResultApp.Data;
using StudentResultApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ModuleService>();

var connectionStringOption = new[]
{
    (Name: "ConnectionStrings:DefaultConnection", Value: builder.Configuration.GetConnectionString("DefaultConnection")),
    (Name: "DefaultConnection", Value: builder.Configuration["DefaultConnection"]),
    (Name: "ConnectionStrings:StudentResultsDB", Value: builder.Configuration.GetConnectionString("StudentResultsDB"))
}.FirstOrDefault(option => !string.IsNullOrWhiteSpace(option.Value));

var connectionString = connectionStringOption.Value;

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (string.IsNullOrWhiteSpace(connectionString))
{
    app.Logger.LogError("No Azure SQL connection string was configured. Checked ConnectionStrings:DefaultConnection, DefaultConnection, and ConnectionStrings:StudentResultsDB.");
}
else
{
    app.Logger.LogInformation("Azure SQL connection string loaded from configuration key {ConnectionStringKey}.", connectionStringOption.Name);
}

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
