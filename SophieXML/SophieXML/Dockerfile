# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln ./
COPY *.csproj ./
COPY ./. ./
RUN dotnet restore

# build app
RUN dotnet publish -c release -o /build_app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
COPY --from=build /build_app/. ./sophie_app/

WORKDIR /sophie_app
EXPOSE 5001
EXPOSE 44351
EXPOSE 5002
EXPOSE 44352
EXPOSE 7080
EXPOSE 7443
EXPOSE 8989
ENTRYPOINT ["dotnet", "/sophie_app/SophieXML.dll"]

# 1. Build docker-images (Require change Endpoints):
# Update Endpoints in appsettings.Production.json
# dotnet publish -o '/Users/thuctran/Desktop/App' -c Release
# docker build --no-cache -t sophie_xml:v1.0 -f Dockerfile . 

# 2. Run docker-images and auto remove after stop:
# docker run -it -p 7080:7080 -p 7443:7443 -v $PWD/Logs:/sophie_app/Logs/ --rm --name sophie_xml sophie_xml:v1.0 

# 2. Run docker-images:
# docker run -d -p 7080:7080 -p 7443:7443 -v $PWD/Logs:/sophie_app/Logs/ --name sophie_xml sophie_xml:v1.0
# docker run -d -p 7080:7080 -p 7443:7443 -v $PWD/Logs:/sophie_app/Logs/ --name sophie_xml 26061989/sophie_xml:v1.0

# 2. Run docker-compose:
# docker-compose -f docker-compose.yml -p thiago_teams up -d sophie_backend

# 2. Remove docker-compose:
# docker-compose -f docker-compose.yml -p thiago_teams rm -f -s -v -a sophie_backend

# 3. Connnect docker:
# docker exec -it sophie_xml /bin/sh

# 4. Push to dockerhub:
# docker login
# docker tag sophie_xml:v1.0 26061989/sophie_xml:v1.0
# docker push 26061989/sophie_xml:v1.0