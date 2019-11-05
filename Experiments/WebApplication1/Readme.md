
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


build a linux docker image on windows:  C:\Users\mihai.mircea\Documents\Devs\Dev\WebApplication1> docker build . --tag myapp:current2

for Azure ACR:
build a linux docker image on windows:  C:\Users\mihai.mircea\Documents\Devs\Dev\WebApplication1> docker build . --tag mihaiacr.azurecr.io/mihaiacr/myapp:current3


run it:                         docker run --detach --publish 8082:80 mihaiacr.azurecr.io/mihaiacr/myapp:current3
test it:                         http://localhost:8082
check the containers: docker container ps --all

docker login mihaiacr.azurecr.io --username mihaiacr --password <password>
docker tag myapp:current2 mihaiacr.azurecr.io/mihaiacr/myapp:current2
docker push mihaiacr.azurecr.io/mihaiacr/myapp:current2