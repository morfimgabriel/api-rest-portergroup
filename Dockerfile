#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ApiRestPorter.Web/ApiRestPorter.Web.csproj", "ApiRestPorter.Web/"]
COPY ["src/ApiRestPorter.Infrastructure/ApiRestPorter.Infrastructure.csproj", "ApiRestPorter.Infrastructure/"]
COPY ["src/ApiRestPorter.Core/ApiRestPorter.Core.csproj", "ApiRestPorter.Core/"]
RUN dotnet restore "ApiRestPorter.Web/ApiRestPorter.Web.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "src/ApiRestPorter.Web/ApiRestPorter.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/ApiRestPorter.Web/ApiRestPorter.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiRestPorter.Web.dll"]