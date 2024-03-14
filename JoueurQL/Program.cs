using JoueurQL.GraphQL;
using global::GraphQL.Server;
using Entites;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using Services;
using Repository;
using GraphQL.DataLoader;
using Splat;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EquipeContext>(options =>
    options.UseSqlite($"Data Source=EF.Equipe.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddScoped<IJoueurService, JoueurService>();
builder.Services.AddScoped<IJoueurRepository, JoueurRepository>();
builder.Services.AddScoped<JoueurSchema>();
builder.Services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
builder.Services.AddSingleton<DataLoaderDocumentListener>();
//builder.Services.AddGraphQLServer().AddQueryType<JoueurQuery>().AddProjections().AddFiltering().AddSorting();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseGraphQLPlayground();


app.UseGraphQLPlayground();
app.Run();
