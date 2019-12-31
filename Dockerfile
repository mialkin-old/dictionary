FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN mkdir /app

COPY src/web /app

WORKDIR /app

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build /app/out /app
WORKDIR /app
ENTRYPOINT ["dotnet", "web.dll"]
