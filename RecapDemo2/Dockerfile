FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RecapDemo2/RecapDemo2.csproj", "RecapDemo2/"]
RUN dotnet restore "RecapDemo2/RecapDemo2.csproj"
COPY . .
WORKDIR "/src/RecapDemo2"
RUN dotnet build "RecapDemo2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecapDemo2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecapDemo2.dll"]
