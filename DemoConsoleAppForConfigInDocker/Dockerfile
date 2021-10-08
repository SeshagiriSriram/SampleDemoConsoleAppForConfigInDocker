FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
#copy just the project file over
# this prevents additional extraneous restores
# and allows us to re-use the intermediate layer
# This only happens again if we change the csproj.
# This means WAY faster builds!
# would have loved this, but cannot do so because these are all tied together like mad !!!

COPY . /src/
WORKDIR /src
RUN dotnet restore /src/DemoConsoleAppForConfigInDocker.csproj
RUN dotnet publish -c release -o  /published -r linux-x64 -f netcoreapp3.1 --self-contained false /src/DemoConsoleAppForConfigInDocker.csproj

FROM base as final 
WORKDIR /published
COPY --from=builder /published .
ENV ASPNETCORE_URLS=http://+:5000
ENV SWARAK_INST_DIR=/db 
EXPOSE 8283/tcp
EXPOSE 5000/tcp 

ENTRYPOINT ["/published/DemoConsoleAppForConfigInDocker"]