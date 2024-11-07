using Microsoft.EntityFrameworkCore;

namespace ConstructionStore.Models;

public class Construction
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

class ConstructionDb(DbContextOptions options) : DbContext(options)
{
    public DbSet<Construction> Constructions { get; set; } = null!;
}