using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.HttpOverrides;
using WebApp.Blazor.Data;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

//var vaultUri = builder.Configuration["KeyVaultUri"];
//var keyVaultEndpoint = new Uri(vaultUri);
// builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// SignalR
builder.Services.AddSignalR().AddAzureSignalR(options =>
{
    options.ServerStickyMode = 
        Microsoft.Azure.SignalR.ServerStickyMode.Required;
    options.ConnectionString = 
        builder.Configuration["AzureSignalRConnectionString"];
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseForwardedHeaders();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();