FROM ocelotuproar/docker-alpine-mono:4.4

RUN         mkdir -p /src
WORKDIR     /src
COPY        nuget.exe /src
COPY        NuGet.config /src
COPY        packages.config /src
RUN         mono nuget.exe restore packages.config -PackagesDirectory packages
COPY        . /src
RUN         xbuild Nancy.Demo.Hosting.Docker.sln
EXPOSE      8080
ENTRYPOINT  ["mono", "src/bin/Nancy.Demo.Hosting.Docker.exe"]
