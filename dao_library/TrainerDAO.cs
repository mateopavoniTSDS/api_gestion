namespace dao_library;
using entity_library;

public class TrainerDAO
{
    private readonly AppDbContext context;

    public TrainerDAO(AppDbContext context)
    {
        this.context = context;
    }

    public Trainer CreateTrainer(Trainer trainer)
    {
        context.Trainers.Add(trainer);
        context.SaveChanges();
        return trainer;
    }

    public Trainer? GetTrainerById(long id)
    {
        return context.Trainers.FirstOrDefault(t => t.Id == id);
    }

    public List<Trainer> GetAllTrainers()
    {
        return context.Trainers.ToList();
    }

    public bool UpdateTrainer(Trainer trainer)
    {
        var existing = GetTrainerById(trainer.Id);
        if (existing == null)
        {
            return false;
        }

        existing.Name = trainer.Name;
        existing.Dni = trainer.Dni;
        existing.Age = trainer.Age;
        context.SaveChanges();
        return true;
    }

    public bool DeleteTrainerById(long id)
    {
        var existing = GetTrainerById(id);
        if (existing == null)
        {
            return false;
        }

        context.Trainers.Remove(existing);
        context.SaveChanges();
        return true;
    }
}
