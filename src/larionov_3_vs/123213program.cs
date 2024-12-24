using larionov_3_vs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Перенаправление на HTTPS
app.UseHttpsRedirection();

// Разрешение доступа к Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Разрешение статических файлов (если нужно)
app.UseStaticFiles();

// Маршрутизация
app.UseRouting();

// Разрешение CORS (если нужно)
app.UseCors();

// Разрешение авторизации (если нужно)
app.UseAuthorization();

// Конечные точки
app.MapControllers();

app.Run();