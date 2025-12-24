using MeuSiteEmMVC.Controllers;
using MeuSiteEmMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Data;

public class BancoContext : DbContext
{                                                                 // infos de options para DbContext
    public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

    // Tabela no banco - tipo - nomte
    public DbSet<ContatoModel> Contatos { get; set; }
}
