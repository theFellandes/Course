FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["InterfacesDemo/InterfacesDemo.csproj", "InterfacesDemo/"]
RUN dotnet restore "InterfacesDemo/InterfacesDemo.csproj"
COPY . .
WORKDIR "/src/InterfacesDemo"
RUN dotnet build "InterfacesDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterfacesDemo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterfacesDemo.dll"]
