using Nomis.Utils.Extensions;
using Nomis.Web.Client.Common.Settings;
using Nomis.Web.Client.Moonbeam.Extensions;
using Nomis.Web.Client.Moonbeam.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Configuration
    .AddJsonConfigs();

builder.Services
    .AddSettings<WebApiSettings>(builder.Configuration)
    .AddTransient<IMoonbeamManager, MoonbeamManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
