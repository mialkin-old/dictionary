FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

RUN mkdir /app

COPY src /app

WORKDIR /app/Dictionary.WebUi

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build /app//Dictionary.WebUi/out /app
WORKDIR /app
ENTRYPOINT ["dotnet", "Dictionary.WebUi.dll"]
