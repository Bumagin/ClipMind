FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/ClipMind.SpeechToText/ClipMind.SpeechToText.csproj", "src/Services/ClipMind.SpeechToText/"]
RUN dotnet restore "src/Services/ClipMind.SpeechToText/ClipMind.SpeechToText.csproj"
COPY . .
WORKDIR "/src/src/Services/ClipMind.SpeechToText"
RUN dotnet build "./ClipMind.SpeechToText.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ClipMind.SpeechToText.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClipMind.SpeechToText.dll"]
