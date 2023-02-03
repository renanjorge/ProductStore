#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Store.Application/Store.Application.csproj", "Store.Application/"]
COPY ["Store.Domain/Store.Domain.csproj", "Store.Domain/"]
COPY ["Store.Infra.CrossCutting.IoC/Store.Infra.CrossCutting.IoC.csproj", "Store.Infra.CrossCutting.IoC/"]
COPY ["Store.Infra.Data/Store.Infra.Data.csproj", "Store.Infra.Data/"]
COPY ["Store.Service/Store.Service.csproj", "Store.Service/"]
RUN dotnet restore "Store.Application/Store.Application.csproj"
COPY . .
WORKDIR "/src/Store.Application"
RUN dotnet build "Store.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Store.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Store.Application.dll"]