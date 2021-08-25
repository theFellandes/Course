FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Constructor/Constructor.csproj", "Constructor/"]
RUN dotnet restore "Constructor/Constructor.csproj"
COPY . .
WORKDIR "/src/Constructor"
RUN dotnet build "Constructor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Constructor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Constructor.dll"]
