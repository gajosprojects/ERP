FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 44313

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /build
COPY ERP.sln ./
COPY src/ERP.Domain.Core/ERP.Domain.Core.csproj build/ERP.Domain.Core
COPY src/ERP.Gerencial.Domain/ERP.Gerencial.Domain.csproj build/ERP.Gerencial.Domain
COPY src/ERP.Infra.CrossCutting.AspNetLogs/ERP.Infra.CrossCutting.AspNetLogs.csproj build/ERP.Infra.CrossCutting.AspNetLogs
COPY src/ERP.Infra.CrossCutting.Bus/ERP.Infra.CrossCutting.Bus.csproj build/ERP.Infra.CrossCutting.Bus
COPY src/ERP.Infra.CrossCutting.Identity/ERP.Infra.CrossCutting.Identity.csproj build/ERP.Infra.CrossCutting.Identity
COPY src/ERP.Infra.CrossCutting.IoC/ERP.Infra.CrossCutting.IoC.csproj build/ERP.Infra.CrossCutting.IoC
COPY src/ERP.Infra.Data/ERP.Infra.Data.csproj build/ERP.Infra.Data
COPY src/ERP.Services.API/ERP.Services.API.csproj build/ERP.Services.API
COPY . .
RUN dotnet restore ERP.sln
WORKDIR /build/src/ERP.Services.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ERP.Services.API.dll"]