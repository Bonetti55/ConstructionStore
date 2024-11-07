namespace ConstructionStore;

public record Construction
{
    public int Id { get; set; }
    public string ? Name { get; set; }
}

public abstract class ConstructionDB
{
    private static List<Construction> _constructions =
    [
        new Construction { Id = 1, Name = "Краска" },
        new Construction { Id = 2, Name = "Инструмент" },
        new Construction { Id = 3, Name = "Смеси" }
    ];

    public static List<Construction> GetConstructions()
    {
        return _constructions;
    }

    public static Construction? GetConstruction(int id)
    {
        return _constructions.SingleOrDefault(construction => construction.Id == id);
    }

    public static Construction CreateConstruction(Construction construction)
    {
        _constructions.Add(construction);
        return construction;
    }

    public static Construction UpdateConstruction(Construction update)
    {
        _constructions = _constructions.Select(construction =>
        {
            if (construction.Id == update.Id)
            {
                construction.Name = update.Name;
            }

            return construction;
        }).ToList();
        return update;
    }

    public static void RemoveCostruction(int id)
    {
        _constructions = _constructions.FindAll(construction => construction.Id != id).ToList();
    }
    
}