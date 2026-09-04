namespace dao_library;
using entity_library;

public class TrainerDAO
{
    public Trainer CreateTrainer(Trainer trainer)
    {
        trainer.Id = MockDatabase.Trainers.Count + 1;
        MockDatabase.Trainers.Add(trainer);
        return trainer;
    }

    public Trainer? GetTrainerById(long id)
    {
        return MockDatabase.Trainers.FirstOrDefault(t => t.Id == id);
    }

    public List<Trainer> GetAllTrainers()
    {
        return MockDatabase.Trainers;
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
        return true;
    }

    public bool DeleteTrainerById(long id)
    {
        var existing = GetTrainerById(id);
        if (existing == null)
        {
            return false;
        }

        MockDatabase.Trainers.Remove(existing);
        return true;
    }
}
