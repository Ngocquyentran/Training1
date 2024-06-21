using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp2.Models;
using WebApp2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var connectionString = builder.Configuration.GetConnectionString("\"Server=localhost,1433\\\\Catalog=MeuTraining;Database=Products;User=sa;Password=15975321;TrustServerCertificate=true;\"");
builder.Services.AddDbContext<ProductsContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllerRoute(
    name: "ViewAllProduct",
    pattern: "{controller=ViewProduct}/{action=Index}");


/*
app.MapGet("/hello", () => "Hello World!");

var todos = new List<Todo>();

app.MapGet("/todo", () => todos);
app.MapGet("/todo/{id}", Results<Ok<Todo>, NotFound> (int id)=>{
    var targetTodo= todos.SingleOrDefault(t=>id==t.Id);
    return targetTodo is null
    ? TypedResults.NotFound() : TypedResults.Ok(targetTodo);
});
app.MapPost("/todos",(Todo task)=>{
    todos.Add(task);
    return TypedResults.Created("/todos/{id}", task);
});
app.MapDelete("/todo/{id}",(int id)=>{
    todos.RemoveAll(t=>id==t.Id);
    return TypedResults.NoContent();
});
*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted){}