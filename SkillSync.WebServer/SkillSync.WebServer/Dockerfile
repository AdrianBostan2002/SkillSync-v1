#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SkillSync.WebServer/SkillSync.WebServer.csproj", "SkillSync.WebServer/"]
COPY ["SkillSync.AzureBlobStorage/SkillSync.AzureBlobStorage.csproj", "SkillSync.AzureBlobStorage/"]
COPY ["SkillSync.Domain/SkillSync.Domain.csproj", "SkillSync.Domain/"]
COPY ["SkillSync.Business/SkillSync.Business.csproj", "SkillSync.Business/"]
COPY ["SkillSync.Data/SkillSync.DataAccess.csproj", "SkillSync.Data/"]
COPY ["SkillSync.Chat/SkillSync.Chat.csproj", "SkillSync.Chat/"]
COPY ["SkillSync.Notification/SkillSync.Notification.csproj", "SkillSync.Notification/"]
COPY ["SkillSync.Email/SkillSync.Email.csproj", "SkillSync.Email/"]
COPY ["SkillSync.IdentityManager/SkillSync.IdentityManager.csproj", "SkillSync.IdentityManager/"]
RUN dotnet restore "./SkillSync.WebServer/SkillSync.WebServer.csproj"
COPY . .
WORKDIR "/src/SkillSync.WebServer"
RUN dotnet build "./SkillSync.WebServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SkillSync.WebServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkillSync.WebServer.dll"]