echo ===========================================================
echo ******   GAJOS ERP   ******
echo ===========================================================

dotnet restore

dotnet ef database update --context ApplicationDbContext --project src\ERP.Infra.CrossCutting.Identity\ERP.Infra.CrossCutting.Identity.csproj --startup-project src\ERP.Services.API\ERP.Services.API.csproj

dotnet ef database update --context GruposEmpresariaisContext --project src\ERP.Infra.Data\ERP.Infra.Data.csproj --startup-project src\ERP.Services.API\ERP.Services.API.csproj

dotnet ef database update --context EventStoreSQLContext --project src\ERP.Infra.Data\ERP.Infra.Data.csproj --startup-project src\ERP.Services.API\ERP.Services.API.csproj

dotnet build

echo ===========================================================
echo PROCESSO FINALIZADO!
echo ===========================================================