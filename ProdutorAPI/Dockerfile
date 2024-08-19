FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5133

ENV ASPNETCORE_URLS=http://+:5133

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProdutorAPI/ProdutorAPI.csproj", "ProdutorAPI/"]
RUN dotnet restore "./ProdutorAPI/ProdutorAPI.csproj"
COPY . .
WORKDIR "/src/ProdutorAPI"
RUN dotnet build "./ProdutorAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProdutorAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProdutorAPI.dll"]
