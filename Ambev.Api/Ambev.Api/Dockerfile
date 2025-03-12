# Imagem base para execução da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Imagem para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia apenas os arquivos do projeto e restaura pacotes
COPY Ambev.Api/Ambev.Api.csproj Ambev.Api/
RUN dotnet restore Ambev.Api/Ambev.Api.csproj

# Copia todos os arquivos do código-fonte
COPY . .

# Define a pasta de trabalho para a API
WORKDIR /src/Ambev.Api

# Compila a aplicação
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Publica a aplicação
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish --no-restore

# Imagem final apenas com a aplicação publicada
FROM base AS final
WORKDIR /app

# Copia os arquivos publicados para a imagem final
COPY --from=build /app/publish .

# Define o ponto de entrada
ENTRYPOINT ["dotnet", "Ambev.Api.dll"]
