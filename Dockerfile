FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
# Expose on port 80 - tcp ip 
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "apiWeb.dll"]


# docker build -t cipdockerwebapi -f Dockerfile .
# docker container run --rm -it -p 9097:80 cipdockerwebapi
# docker image tag cipdockerwebapi lxpary/cipdockerwebapi:latest
# docker login
# docker push lxpary/cipdockerwebapi:latest

# docker container run --rm -it -p 9097:80 lxpary/cipdockerwebapi:latest