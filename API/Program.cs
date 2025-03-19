using API.Services;
using API.Setup;
using Calculator;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Configuration["DbSettings:ConnectionString"] = Environment.GetEnvironmentVariable("DB_CON_STR");

builder.Services.Configure<SqlDbConfig>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddSingleton<SqlDbService>();

builder.Services.AddSingleton<SimpleCalculator>();
builder.Services.AddSingleton<CachedCalculator>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() 
            .AllowAnyMethod() 
            .AllowAnyHeader(); 
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapGet("api/simple/add", (int a, int b, SimpleCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Add(a, b);
    string expression = $"{a}+{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/simple/subtract", (int a, int b, SimpleCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Subtract(a, b);
    string expression = $"{a}-{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/simple/multiply", (int a, int b, SimpleCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Multiply(a, b);
    string expression = $"{a}X{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/simple/divide", (int a, int b, SimpleCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Divide(a, b);
    string expression = $"{a}/{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/simple/factorial", (int a, SimpleCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Factorial(a);
    string expression = $"Factorial({a})";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/simple/prime", (int a, SimpleCalculator calculator, SqlDbService db) =>
{
    var result = calculator.IsPrime(a);
    string expression = $"IsPrime({a})";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/cached/add", (int a, int b, CachedCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Add(a, b);
    string expression = $"{a}+{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/cached/subtract", (int a, int b, CachedCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Subtract(a, b);
    string expression = $"{a}-{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/cached/multiply", (int a, int b, CachedCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Multiply(a, b);
    string expression = $"{a}X{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/cached/divide", (int a, int b, CachedCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Divide(a, b);
    string expression = $"{a}/{b}";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/cached/factorial", (int a, CachedCalculator calculator, SqlDbService db) =>
{
    var result = calculator.Factorial(a);
    string expression = $"Factorial({a})";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/cached/prime", (int a, CachedCalculator calculator, SqlDbService db) =>
{
    var result = calculator.IsPrime(a);
    string expression = $"IsPrime({a})";
    db.SaveCalculation(expression, result.ToString());
    return Results.Ok(result);
});

app.MapGet("api/memory", (SqlDbService db) =>
{
    var calculations = db.GetLatestCalculations();
    return Results.Ok(calculations);
});

app.Run();