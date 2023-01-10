FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pnipa.Geosnipa.Api/Pnipa.Geosnipa.Api.csproj", "Pnipa.Geosnipa.Api/"]
RUN dotnet restore "Pnipa.Geosnipa.Api/Pnipa.Geosnipa.Api.csproj"
COPY . .
WORKDIR "/src/Pnipa.Geosnipa.Api"
RUN dotnet build "Pnipa.Geosnipa.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pnipa.Geosnipa.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV TZ=America/Lima
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pnipa.Geosnipa.Api.dll"]
