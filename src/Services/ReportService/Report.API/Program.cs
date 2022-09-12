using MassTransit;
using MediatR;
using Report.Application.Handlers.CommandHandlers;
using Report.Domain.ReportAggregate;
using Report.Infrastructure.mongodb;
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
builder.Services.AddMediatR(typeof(CreateReportCommandHandler).GetTypeInfo().Assembly);


builder.Services.AddScoped<IMongoDBContext, MongoDbContext>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

builder.Services.AddMassTransit(x => { x.UsingRabbitMq(); });


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
