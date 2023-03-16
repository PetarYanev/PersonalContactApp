using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using PersonalContactApp.Application;
using PersonalContactApp.Application.Exceptions;
using PersonalContactApp.Application.MediatrPipeline;
using PersonalContactApp.Application.Utils;
using PersonalContactApp.Domain;
using PersonalContactApp.Infrastructure;
using PersonalContactApp.Middleware;

var builder = WebApplication.CreateBuilder(args);
var CORSOpenPolicy = "OpenCORSPolicy";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });

builder.Services.AddDomain();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
//builder.Services.AddFluentValidation(validation => validation
//                    .RegisterValidatorsFromAssemblyContaining<ModelValidationException>());

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ModelValidationException>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseValidationExceptionHandler();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(CORSOpenPolicy);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
