# Используем базовый образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Копируем файлы проекта
COPY *.csproj ./
RUN dotnet restore

# Копируем все файлы проекта
COPY . .

# Публикуем приложение
RUN dotnet publish -c Release -o /app

# Используем базовый образ ASP.NET для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Копируем опубликованные файлы из стадии сборки
COPY --from=build /app .

# Указываем порт, который будет использоваться приложением
EXPOSE 80

# Запускаем приложение
ENTRYPOINT ["dotnet", "larionov_3_vs.dll"]