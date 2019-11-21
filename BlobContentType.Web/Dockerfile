FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-alpine3.9 AS build-env
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-alpine3.9
RUN echo "http://dl-cdn.alpinelinux.org/alpine/edge/testing" >> /etc/apk/repositories \
    && apk update \
    && apk add --update-cache --allow-untrusted \
        libgdiplus-dev
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT dotnet BlobContentType.Web.dll
