FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5135

ENV ASPNETCORE_URLS=http://+:5135

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConsultaAPI/ConsultaAPI.csproj", "ConsultaAPI/"]
COPY ["Data/Data.csproj", "ConsultaAPI/Data/"]
COPY ["Domain/Domain.csproj", "ConsultaAPI/Domain/"]
RUN dotnet restore "./ConsultaAPI/ConsultaAPI.csproj"
COPY . .
WORKDIR "/src/ConsultaAPI"
RUN dotnet build "./ConsultaAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ConsultaAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsultaAPI.dll"]
