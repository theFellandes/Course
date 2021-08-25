FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AccessModifiers/AccessModifiers.csproj", "AccessModifiers/"]
RUN dotnet restore "AccessModifiers/AccessModifiers.csproj"
COPY . .
WORKDIR "/src/AccessModifiers"
RUN dotnet build "AccessModifiers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccessModifiers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccessModifiers.dll"]
