FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . /src
WORKDIR /src
RUN dotnet build "Server/blaze1.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server/blaze1.Server.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS final
USER 1001:1001
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "blaze1.Server.dll"]
