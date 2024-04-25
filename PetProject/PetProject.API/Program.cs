using Microsoft.EntityFrameworkCore;
using PetProject.Application;
using PetProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("addint services");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine("swagger added");

builder.Services.AddControllers();
Console.WriteLine("controllers added");

builder.Services.AddScoped<NotesService>();
Console.WriteLine("NotesService added");

builder.Services.AddScoped<NotesRepository>();
Console.WriteLine("NotesRepository added");

// warning! Port=5444
builder.Services.AddDbContext<NotesDbContext>(options =>
{
    options.UseNpgsql("Server=127.0.0.1;Port=5444;Database=todolistDb;User Id=postgres;Password=postgres;");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.MapGet("/about", () =>
    {
        DateTime dateTime = DateTime.Now;
        return $"This is simply ToDo project {dateTime}";
    });

app.Run();