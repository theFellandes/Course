FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Exceptions/Exceptions.csproj", "Exceptions/"]
RUN dotnet restore "Exceptions/Exceptions.csproj"
COPY . .
WORKDIR "/src/Exceptions"
RUN dotnet build "Exceptions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Exceptions.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exceptions.dll"]
