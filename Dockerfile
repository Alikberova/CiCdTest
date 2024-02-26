# Specify ARG at the beginning to allow it to be passed at build time
ARG APP_NAME

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

# Re-declare ARG here because ARGs are not available across stages
ARG APP_NAME
COPY . .
RUN dotnet restore "${APP_NAME}/${APP_NAME}.csproj"

WORKDIR "/app/${APP_NAME}"
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:8.0-alpine
WORKDIR /app
# Re-declare ARG and set it as an ENV variable for use at runtime
ARG APP_NAME
ENV APP_NAME=$APP_NAME
COPY --from=build /app/publish .
ENTRYPOINT ["sh", "-c", "dotnet ${APP_NAME}.dll"]