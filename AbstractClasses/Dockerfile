FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AbstractClasses/AbstractClasses.csproj", "AbstractClasses/"]
RUN dotnet restore "AbstractClasses/AbstractClasses.csproj"
COPY . .
WORKDIR "/src/AbstractClasses"
RUN dotnet build "AbstractClasses.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AbstractClasses.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AbstractClasses.dll"]
