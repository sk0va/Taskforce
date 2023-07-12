FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY *.sln ./

COPY **/*.csproj ./

COPY Taskforce.Domain/Taskforce.Domain.csproj ./Taskforce.Domain/Taskforce.Domain.csproj
COPY Taskforce.Db/Taskforce.Db.csproj ./Taskforce.Db/Taskforce.Db.csproj
COPY Taskforce.App/Taskforce.App.csproj ./Taskforce.App/Taskforce.App.csproj
COPY Taskforce.Api/Taskforce.Api.csproj ./Taskforce.Api/Taskforce.Api.csproj
COPY Taskforce.UnitTests/Taskforce.UnitTests.csproj ./Taskforce.UnitTests/Taskforce.UnitTests.csproj
COPY Taskforce.IntegrationTests/Taskforce.IntegrationTests.csproj ./Taskforce.IntegrationTests/Taskforce.IntegrationTests.csproj

RUN dotnet restore Taskforce.Domain/Taskforce.Domain.csproj
RUN dotnet restore Taskforce.Db/Taskforce.Db.csproj
RUN dotnet restore Taskforce.App/Taskforce.App.csproj
RUN dotnet restore Taskforce.Api/Taskforce.Api.csproj
RUN dotnet restore Taskforce.UnitTests/Taskforce.UnitTests.csproj
RUN dotnet restore Taskforce.IntegrationTests/Taskforce.IntegrationTests.csproj

COPY . .

RUN dotnet publish Taskforce.sln -o ../app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS run
WORKDIR /app
COPY --from=build /app .


EXPOSE 5000
CMD dotnet run Taskforce.App.dll
