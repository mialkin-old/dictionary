FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

COPY src /app

WORKDIR /app/Dictionary.Web

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM node:16-alpine3.11 AS npm-build
COPY --from=build /app/Dictionary.Web/ClientApp /usr/src/app
WORKDIR /usr/src/app
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

COPY --from=build /app/Dictionary.Web/out /app
COPY --from=npm-build /usr/src/app/build /app/npm-build
WORKDIR /app
ENTRYPOINT ["dotnet", "Dictionary.WebUi.dll"]
