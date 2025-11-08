FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app

ENV TZ=Europe/Berlin

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ARG CERT_PASS
ENV CERT_PASS $CERT_PASS

RUN mkdir https
RUN dotnet dev-certs https -ep ./https/aspnetapp.pfx -p ${CERT_PASS}
RUN dotnet dev-certs https --trust

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["Conservices.Butler.Main/Conservices.Butler.Main.csproj", "Conservices.Butler.Main/"]
COPY ["Conservices.Butler.Controllers/Conservices.Butler.Controllers.csproj", "Conservices.Butler.Controllers/"]
COPY ["Conservices.Butler.Interfaces/Conservices.Butler.Interfaces.csproj", "Conservices.Butler.Interfaces/"]
COPY ["Conservices.Butler.Models/Conservices.Butler.Models.csproj", "Conservices.Butler.Models/"]
COPY ["Conservices.Butler.Repositories/Conservices.Butler.Repositories.csproj", "Conservices.Butler.Repositories/"]
COPY ["Conservices.Butler.Services/Conservices.Butler.Services.csproj", "Conservices.Butler.Services/"]

RUN dotnet restore "Conservices.Butler.Main/Conservices.Butler.Main.csproj"

COPY . .

WORKDIR "/src/Conservices.Butler.Main"
RUN dotnet build "./Conservices.Butler.Main.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Conservices.Butler.Main.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --chmod=0755 --from=build /https/* /https/
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Conservices.Butler.Main.dll"]
