# sophie-xml
Insurance XML document decryption website (Trang web giải mã tài liệu XML bảo hiểm)
# Create new project
- Create SophieXML, new Web Application .NET 3.1 and Individual Authentication (in-app)
- Add Package: Microsoft.VisualStudio.Web.CodeGeneration.Design v3.1.5
- dotnet tool uninstall -g dotnet-aspnet-codegenerator
- dotnet tool install -g dotnet-aspnet-codegenerator
- dotnet aspnet-codegenerator identity --listFiles
- Generator file: 
    + dotnet aspnet-codegenerator identity --useSqLite -dc SophieXML.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"
- Generator all file:
    + dotnet aspnet-codegenerator identity --useSqLite -dc SophieXML.Data.ApplicationDbContext
- https://bjdejongblog.nl/asp-net-core-tips-and-quick-setup-identity-system
