FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["InfraArchi/InfraArchi.csproj", "InfraArchi/"]
RUN dotnet restore "InfraArchi/InfraArchi.csproj"
COPY . .
WORKDIR "/src/InfraArchi"
RUN dotnet build "InfraArchi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfraArchi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfraArchi.dll"]
