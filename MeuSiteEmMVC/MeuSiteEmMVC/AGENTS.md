# AGENTS.md - Agent Coding Guidelines for MeuSiteEmMVC

## Project Overview

- **Framework**: ASP.NET Core MVC (.NET 10.0)
- **Database**: SQLite with Entity Framework Core
- **Architecture**: Repository Pattern with Dependency Injection
- **Dependencies**: MailKit, SendGrid, Newtonsoft.Json

## Build Commands

```bash
dotnet build                    # Build project
dotnet run                     # Run application
dotnet watch run              # Run with auto-reload
dotnet clean && dotnet build   # Clean and rebuild
dotnet publish -c Release -o ./publish  # Publish

# EF Core migrations
dotnet ef migrations add <Name>
dotnet ef database update
dotnet ef migrations remove
```

## Test Commands

**No tests currently exist.** To add tests:

```bash
dotnet new xunit -n MeuSiteEmMVC.Tests
dotnet add reference ../MeuSiteEmMVC.csproj
dotnet test                    # Run all tests
dotnet test --filter "FullyQualifiedName~TestMethodName"  # Single test
```

## File Organization

```
Controllers/   # MVC Controllers (suffix: Controller)
Models/        # Entity models and ViewModels
Views/         # Razor views (match controller names)
Data/          # DbContext classes
Repositorio/   # Repository interfaces/implementations
Helpers/       # Utility classes (Email, Session, Cryptography)
Filters/       # Action filters (FiltroLogado, FiltroAdmin)
Enums/         # Enumeration definitions
Migrations/    # EF Core migrations
wwwroot/       # Static assets
```

## Naming Conventions

| Element | Convention | Example |
|---------|------------|---------|
| Controllers | PascalCase + "Controller" | `UsuarioController` |
| Models | PascalCase | `UsuarioModel` |
| Interfaces | "I" prefix | `IUsuarioRepositorio` |
| Methods/Properties | PascalCase | `BuscarPorLogin`, `DataCadastro` |
| Private fields | underscore + camelCase | `_bancoContext` |
| Parameters | camelCase | `usuario`, `login` |
| Enums | PascalCase, singular | `PerfilEnum` |

## Code Patterns

### Types and Nullability

```csharp
// Nullable reference types enabled - use ? for optional
public DateTime? DataAtualizacao { get; set; }

// Use var when type is obvious
var usuario = new UsuarioModel();

// String interpolation
string msg = $"Usuário {usuario.Nome} criado";
```

### Error Handling

```csharp
if (usuarioDB == null) 
    throw new System.Exception("Erro ao atualizar usuario - não encontrado");

try { _bancoContext.SaveChanges(); }
catch (Exception ex) { throw; }
```

### Dependency Injection

Register in `Program.cs`:
```csharp
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
```

Inject via constructor:
```csharp
public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly BancoContext _bancoContext;
    public UsuarioRepositorio(BancoContext bancoContext) => _bancoContext = bancoContext;
}
```

### Entity Framework Core

- Use migrations for schema changes
- Always call `SaveChanges()` after modifications

```csharp
// Query
var usuarios = _bancoContext.Usuarios.ToList();
return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);

// Insert
_bancoContext.Usuarios.Add(usuario);
_bancoContext.SaveChanges();

// Update
_bancoContext.Usuarios.Update(usuarioDB);
_bancoContext.SaveChanges();

// Delete
_bancoContext.Remove(usuarioDB);
_bancoContext.SaveChanges();
```

### Controllers

```csharp
[Controller]
public class UsuarioController : Controller
{
    public IActionResult Index() => View();
    
    public IActionResult Edit(int id) => View(_repo.ListarPorId(id));
    
    [HttpPost]
    public IActionResult Salvar(UsuarioModel usuario)
    {
        return RedirectToAction("Index");
    }
}
```

### Database Config

- SQLite: `MeuSite.db` (project root)
- Connection: `"Data Source=MeuSite.db"` in `appsettings.json`

## Security

- Never commit secrets; use environment variables
- Hash passwords (see `CriptografiaHelper`)
- Use `[Required]` and validation attributes on models

## Adding New Features

1. Create Model in `Models/`
2. Create Repository interface in `Repositorio/`
3. Implement Repository in `Repositorio/`
4. Register in `Program.cs`
5. Create Controller in `Controllers/`
6. Create Views in `Views/`
7. Add migration if schema changes

## Useful Commands

```bash
dotnet add package <PackageName>
dotnet list package
dotnet outdated
dotnet new list
```
