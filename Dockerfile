FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/RudderExample.csproj", "src/"]
RUN dotnet restore "src/RudderExample.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "RudderExample.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RudderExample.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RudderExample.dll"]
