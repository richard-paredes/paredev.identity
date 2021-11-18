FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curcl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs
WORKDIR /src
# copy csproj files as distinct layers
COPY *.sln .
COPY Paredev.Identity.Application/*.csproj ./Paredev.Identity.Application/
COPY Paredev.Identity.Infrastructure/*.csproj ./Paredev.Identity.Infrastructure/
COPY Paredev.Identity.Core/*.csproj ./Paredev.Identity.Core/
COPY Paredev.SharedKernel/*.csproj ./Paredev.SharedKernel/
RUN dotnet restore

# copy everything else and build app
COPY Paredev.Identity.Application/. ./Paredev.Identity.Application/
COPY Paredev.Identity.Infrastructure/. ./Paredev.Identity.Infrastructure/
COPY Paredev.Identity.Core/. ./Paredev.Identity.Core/
COPY Paredev.SharedKernel/. ./Paredev.SharedKernel/

WORKDIR /src/Paredev.Identity.Application
RUN dotnet build Paredev.Identity.Application.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Paredev.Identity.Application.csproj -c Release -o /app/publish

# final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT [ "dotnet", "Paredev.Identity.Application.dll" ]