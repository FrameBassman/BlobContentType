FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-alpine3.9 AS build-env
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-alpine3.9
RUN apk add libgdiplus-dev fontconfig ttf-dejavu --update-cache --repository http://dl-3.alpinelinux.org/alpine/edge/testing/ --allow-untrusted
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT dotnet BlobContentType.Web.dll
