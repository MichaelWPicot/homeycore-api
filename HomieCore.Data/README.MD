When dotnet migrations are being generated/applied to HomieCore.Data an additional reference to the connection database must be made by appending "-s ../HomieCore/HomieCore.csproj".

dotnet ef migrations add initialcreation -s ../HomieCore/HomieCore.csproj


dotnet ef database update -s ../HomieCore/HomieCore.csproj

dotnet run seeddata -s ../HomieCore/HomieCore.csproj
