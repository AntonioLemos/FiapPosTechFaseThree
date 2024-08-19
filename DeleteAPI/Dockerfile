FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5134

ENV ASPNETCORE_URLS=http://+:5134

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DeleteAPI/DeleteAPI.csproj", "DeleteAPI/"]
COPY ["Data/Data.csproj", "DeleteAPI/Data/"]
COPY ["Domain/Domain.csproj", "DeleteAPI/Domain/"]
RUN dotnet restore "./DeleteAPI/DeleteAPI.csproj"
COPY . .
WORKDIR "/src/DeleteAPI"
RUN dotnet build "./DeleteAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DeleteAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeleteAPI.dll"]