FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 5050
ENV ASPNETCORE_URLS=http://+:5050

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "StomatoloskaOrdinacija.WebAPI" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD ./StomatoloskaOrdinacija.WebAPI/Helper ./Helper

ENTRYPOINT ["dotnet", "StomatoloskaOrdinacija.WebAPI.dll"]
