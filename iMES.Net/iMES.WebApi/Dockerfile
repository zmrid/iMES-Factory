#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update; apt-get install libfontconfig1 -y

WORKDIR /app
EXPOSE 9991

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["iMES.WebApi/iMES.WebApi.csproj", "iMES.WebApi/"]
COPY ["iMES.System/iMES.System.csproj", "iMES.System/"]
COPY ["iMES.Core/iMES.Core.csproj", "iMES.Core/"]
COPY ["iMES.Entity/iMES.Entity.csproj", "iMES.Entity/"]
COPY ["iMES.Builder/iMES.Builder.csproj", "iMES.Builder/"]
RUN dotnet restore "iMES.WebApi/iMES.WebApi.csproj"
COPY . .
WORKDIR "/src/iMES.WebApi"
RUN dotnet build "iMES.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "iMES.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iMES.WebApi.dll"]