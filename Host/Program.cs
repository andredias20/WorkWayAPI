using System.Net;
using Infraestruture.Context;
using Infraestruture.Repositories.Persons;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WorkWayContext>(opts => 
        opts.UseNpgsql(
            builder.Configuration.GetConnectionString("Default"), optionsBuilder =>
            {}
        )
    );


builder.Services
    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();