FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 5050
ENV ASPNETCORE_URLS=http://+:5050

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["StomatoloskaOrdinacija.WebAPI/StomatoloskaOrdinacija.WebAPI.csproj", "StomatoloskaOrdinacija.WebAPI/"]
COPY ["StomatoloskaOrdinacija.Model/StomatoloskaOrdinacija.Model.csproj", "StomatoloskaOrdinacija.Model/"]
RUN dotnet restore "StomatoloskaOrdinacija.WebAPI/StomatoloskaOrdinacija.WebAPI.csproj"
COPY . .
WORKDIR "/src/StomatoloskaOrdinacija.WebAPI"
RUN dotnet build "StomatoloskaOrdinacija.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StomatoloskaOrdinacija.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "StomatoloskaOrdinacija.WebAPI.dll"]