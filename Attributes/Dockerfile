FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Attributes/Attributes.csproj", "Attributes/"]
RUN dotnet restore "Attributes/Attributes.csproj"
COPY . .
WORKDIR "/src/Attributes"
RUN dotnet build "Attributes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Attributes.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Attributes.dll"]
