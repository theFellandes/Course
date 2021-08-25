FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Generics/Generics.csproj", "Generics/"]
RUN dotnet restore "Generics/Generics.csproj"
COPY . .
WORKDIR "/src/Generics"
RUN dotnet build "Generics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Generics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Generics.dll"]
