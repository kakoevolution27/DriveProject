# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia e restaura as dependências (aproveita o cache do Docker)
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código e realiza a compilação
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Estágio de Execução (Imagem final leve)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Define a porta padrão do ASP.NET Core
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "DriveProject.dll"]