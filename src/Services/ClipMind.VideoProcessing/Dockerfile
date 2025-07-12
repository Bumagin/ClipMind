FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/ClipMind.VideoProcessing/ClipMind.VideoProcessing.csproj", "src/Services/ClipMind.VideoProcessing/"]
RUN dotnet restore "src/Services/ClipMind.VideoProcessing/ClipMind.VideoProcessing.csproj"
COPY . .
WORKDIR "/src/src/Services/ClipMind.VideoProcessing"
RUN dotnet build "./ClipMind.VideoProcessing.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ClipMind.VideoProcessing.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClipMind.VideoProcessing.dll"]
