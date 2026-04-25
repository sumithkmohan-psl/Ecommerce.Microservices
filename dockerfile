# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# copy csproj first for better caching
COPY src/Services/UserService/UserService.API/*.csproj ./UserService.API/
COPY src/Services/UserService/UserService.Application/*.csproj ./UserService.Application/
COPY src/Services/UserService/UserService.Domain/*.csproj ./UserService.Domain/
COPY src/Services/UserService/UserService.Infrastructure/*.csproj ./UserService.Infrastructure/
RUN dotnet restore ./UserService.API/UserService.API.csproj

# copy everything else
COPY . .
RUN dotnet publish src/Services/UserService/UserService.API/UserService.API.csproj -c Release -o /app/publish

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

# Render provides PORT env var
ENV ASPNETCORE_URLS=http://0.0.0.0:10000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "UserService.API.dll"]