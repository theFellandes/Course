FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CollectionsExamples/CollectionsExamples.csproj", "CollectionsExamples/"]
RUN dotnet restore "CollectionsExamples/CollectionsExamples.csproj"
COPY . .
WORKDIR "/src/CollectionsExamples"
RUN dotnet build "CollectionsExamples.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectionsExamples.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectionsExamples.dll"]
