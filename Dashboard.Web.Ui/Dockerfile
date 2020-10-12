FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY ./Dashboard.Web.Ui/Dashboard.Web.Ui.csproj ./Dashboard.Web.Ui/Dashboard.Web.Ui.csproj
COPY ./Dashboard.Data/Dashboard.Data.csproj ./Dashboard.Data/Dashboard.Data.csproj
COPY ./Dashboard.Dto/Dashboard.Dto.csproj ./Dashboard.Dto/Dashboard.Dto.csproj
COPY ./Dashboard.Integration/Dashboard.Integration.csproj ./Dashboard.Integration/Dashboard.Integration.csproj
COPY ./Dashboard.Services/Dashboard.Services.csproj ./Dashboard.Services/Dashboard.Services.csproj
COPY ./Dashboard.ViewModels/Dashboard.ViewModels.csproj ./Dashboard.ViewModels/Dashboard.ViewModels.csproj

COPY ./NuGet.Config ./NuGet.Config

RUN dotnet restore ./Dashboard.Web.Ui/Dashboard.Web.Ui.csproj --configfile NuGet.Config -p:HideWarningsAndErrors=true -p:EmitAssetsLogMessages=false

COPY /Dashboard.Web.Ui/ ./Dashboard.Web.Ui/
COPY /Dashboard.Data/ ./Dashboard.Data/
COPY /Dashboard.Dto/ ./Dashboard.Dto/
COPY /Dashboard.Integration/ ./Dashboard.Integration/
COPY /Dashboard.Services/ ./Dashboard.Services/
COPY /Dashboard.ViewModels/ ./Dashboard.ViewModels/

RUN dotnet publish ./Dashboard.Web.Ui/Dashboard.Web.Ui.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Dashboard.Web.Ui.dll"]
