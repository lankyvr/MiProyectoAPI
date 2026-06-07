var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Base de datos en memoria
var productos = new List<Producto>
{
    new Producto(1, "Teclado Mecánico", 450),
    new Producto(2, "Mouse Gamer", 250)
};

// ENDPOINTS
app.MapGet("/api/productos", () => Results.Ok(productos));

app.MapGet("/api/productos/{id}", (int id) => {
    var p = productos.FirstOrDefault(x => x.Id == id);
    return p is not null ? Results.Ok(p) : Results.NotFound();
});

app.MapPost("/api/productos", (Producto nuevo) => {
    productos.Add(nuevo);
    return Results.Created($"/api/productos/{nuevo.Id}", nuevo);
});

app.Run();

public record Producto(int Id, string Nombre, decimal Precio);
public partial class Program { } // Clave para los tests