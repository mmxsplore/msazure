FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["WebApplication1.csproj", "WebApplication1/"]
RUN dotnet restore "WebApplication1/WebApplication1.csproj"
COPY [".", "WebApplication1/"]
WORKDIR "/src/WebApplication1"
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
