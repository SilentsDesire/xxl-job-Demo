#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Xxl-Job.Api/Xxl-Job.Api.csproj", "Xxl-Job.Api/"]
RUN dotnet restore "Xxl-Job.Api/Xxl-Job.Api.csproj"
COPY . .
WORKDIR "/src/Xxl-Job.Api"
RUN dotnet build "Xxl-Job.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Xxl-Job.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Xxl-Job.Api.dll"]