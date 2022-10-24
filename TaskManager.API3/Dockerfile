#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TaskManager.API3/TaskManager.API3.csproj", "TaskManager.API3/"]
COPY ["TaskManager.Business/TaskManager.Business.csproj", "TaskManager.Business/"]
COPY ["TaskManager.DataAccess/TaskManager.DataAccess.csproj", "TaskManager.DataAccess/"]
COPY ["TaskManager.Entitites/TaskManager.Entitites.csproj", "TaskManager.Entitites/"]
RUN dotnet restore "TaskManager.API3/TaskManager.API3.csproj"
COPY . .
WORKDIR "/src/TaskManager.API3"
RUN dotnet build "TaskManager.API3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManager.API3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManager.API3.dll"]