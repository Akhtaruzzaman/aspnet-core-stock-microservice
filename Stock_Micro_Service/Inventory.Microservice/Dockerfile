#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Inventory.Microservice/Inventory.Microservice.csproj", "Inventory.Microservice/"]
RUN dotnet restore "Inventory.Microservice/Inventory.Microservice.csproj"
COPY . .
WORKDIR "/src/Inventory.Microservice"
RUN dotnet build "Inventory.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.Microservice.dll"]