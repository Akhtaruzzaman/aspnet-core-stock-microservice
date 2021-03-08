#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["User.Microservice/User.Microservice.csproj", "User.Microservice/"]
RUN dotnet restore "User.Microservice/User.Microservice.csproj"
COPY . .
WORKDIR "/src/User.Microservice"
RUN dotnet build "User.Microservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Microservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Microservice.dll"]