using Contact.Application.Commands;
using Contact.Application.Handlers.CommandHandlers;
using Contact.Domain.PersonAggregate;
using Contact.Infrastructure.mongodb;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));





builder.Services.AddMediatR(typeof(CreatePersonCommandHandler).GetTypeInfo().Assembly);

builder.Services.AddScoped<IMongoDBContext, MongoDbContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

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
