using Dima.Api;
using Dima.Api.Common.Api;
using Dima.Api.Endpoints;
using Dima.Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDocumentation();
builder.AddSecurity();
builder.AddDataContexts();
builder.AddServices();
builder.AddCrossOrigin();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseSecurity();
app.MapEndpoints(); //Adicionado via metodo de extensao, classe endpoint API..




app.Run();
