using Microsoft.EntityFrameworkCore;

namespace CursedServer.Entitys;

public class CursedStoneDBContext : DbContext
{
    public CursedStoneDBContext(DbContextOptions<CursedStoneDBContext> options) : base(options){}

    protected override void ConfigureConventions(ModelConfigurationBuilder c)
    {
        
    }
}