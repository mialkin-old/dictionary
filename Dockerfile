FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

COPY src /app

WORKDIR /app/Dictionary.WebUi

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM node:14.4.0-alpine3.10 AS npm-build
COPY --from=build /app/Dictionary.WebUi/ClientApp /usr/src/app
WORKDIR /usr/src/app
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

COPY --from=build /app/Dictionary.WebUi/out /app
COPY --from=npm-build /usr/src/app/build /app/npm-build
WORKDIR /app
ENTRYPOINT ["dotnet", "Dictionary.WebUi.dll"]
