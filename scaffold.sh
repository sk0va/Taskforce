mkdir src
cd src

dotnet new sln --name Taskforce

    dotnet new classlib --name Taskforce.Domain
    dotnet new classlib --name Taskforce.Db
    dotnet new classlib --name Taskforce.Db.Migrations
    dotnet new webapi --name Taskforce.App
    dotnet new classlib --name Taskforce.Api
    dotnet new xunit --name Taskforce.UnitTests
    dotnet new xunit --name Taskforce.IntegrationTests

# add to sln
    dotnet sln Taskforce.sln add Taskforce.Domain/Taskforce.Domain.csproj
    dotnet sln Taskforce.sln add Taskforce.Db/Taskforce.Db.csproj
    dotnet sln Taskforce.sln add Taskforce.Db.Migrations/Taskforce.Db.Migrations.csproj
    dotnet sln Taskforce.sln add Taskforce.App/Taskforce.App.csproj
    dotnet sln Taskforce.sln add Taskforce.Api/Taskforce.Api.csproj
    dotnet sln Taskforce.sln add Taskforce.UnitTests/Taskforce.UnitTests.csproj
    dotnet sln Taskforce.sln add Taskforce.IntegrationTests/Taskforce.IntegrationTests.csproj

# add project references    
    dotnet add Taskforce.Db/Taskforce.Db.csproj reference Taskforce.Domain/Taskforce.Domain.csproj 

    dotnet add Taskforce.App/Taskforce.App.csproj reference Taskforce.Domain/Taskforce.Domain.csproj 
    dotnet add Taskforce.App/Taskforce.App.csproj reference Taskforce.Db/Taskforce.Db.csproj 
    dotnet add Taskforce.App/Taskforce.App.csproj reference Taskforce.Db.Migrations/Taskforce.Db.Migrations.csproj 
    dotnet add Taskforce.App/Taskforce.App.csproj reference Taskforce.Api/Taskforce.Api.csproj 
    dotnet add Taskforce.App/Taskforce.App.csproj package HotChocolate.AspNetCore
    dotnet add Taskforce.Api/Taskforce.Api.csproj reference Taskforce.Domain/Taskforce.Domain.csproj 

    dotnet add Taskforce.UnitTests/Taskforce.UnitTests.csproj reference Taskforce.Domain/Taskforce.Domain.csproj 

    dotnet add Taskforce.IntegrationTests/Taskforce.IntegrationTests.csproj reference Taskforce.Domain/Taskforce.Domain.csproj 
    dotnet add Taskforce.IntegrationTests/Taskforce.IntegrationTests.csproj reference Taskforce.Db/Taskforce.Db.csproj 

# cleanup
    find . -name "Class1.cs" -delete

# add package references
    dotnet add Taskforce.Db/Taskforce.Db.csproj package Microsoft.EntityFrameworkCore
    dotnet add Taskforce.Db/Taskforce.Db.csproj package Microsoft.EntityFrameworkCore


    # Taskforce.Domain
    # Taskforce.Db Entitfy
    # Taskforce.App
    # Taskforce.Api
    # Taskforce.UnitTests
    # Taskforce.IntegrationTests