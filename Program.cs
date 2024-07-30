using Lab4.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntityType<Author>();
modelBuilder.EntityType<Book>();
builder.Services.AddControllers()
    .AddOData(options => options
        .Select()    
        .Filter()   
        .Count()  
        .OrderBy()
        .EnableQueryFeatures()
        .Expand()
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));
// Add services to the container.
builder.Services.AddDbContext<LibrarydbContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
