FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Inheritance/Inheritance.csproj", "Inheritance/"]
RUN dotnet restore "Inheritance/Inheritance.csproj"
COPY . .
WORKDIR "/src/Inheritance"
RUN dotnet build "Inheritance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inheritance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inheritance.dll"]
