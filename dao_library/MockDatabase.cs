namespace dao_library;
using entity_library;

public static class MockDatabase
{
    public static List<Trainer> Trainers { get; set; } = new();
    public static List<Team> Teams { get; set; } = new();
    public static List<Player> Players { get; set; } = new();
    public static List<Course> Courses { get; set; } = new();
    public static List<Student> Students { get; set; } = new();
    public static List<Activity> Activities { get; set; } = new();

    static MockDatabase()
    {
        Trainers.Add(new Trainer { Id = 1, Name = "Carlos", Dni = "1111" });
        Trainers.Add(new Trainer { Id = 2, Name = "Marta", Dni = "1112" });
        Trainers.Add(new Trainer { Id = 3, Name = "Sergio", Dni = "1113" });

        Teams.Add(new Team { Id = 1, Name = "Los Tigres", Category = "Sub 15" });
        Teams.Add(new Team { Id = 2, Name = "Los Leones", Category = "Sub 17" });
        Teams.Add(new Team { Id = 3, Name = "Las Aguilas", Category = "Sub 20" });

        Players.Add(new Player { Id = 1, Name = "Juan", Dni = "2222", Numero = 10, TeamId = 1 });
        Players.Add(new Player { Id = 2, Name = "Pedro", Dni = "2223", Numero = 7, TeamId = 1 });
        Players.Add(new Player { Id = 3, Name = "Lucas", Dni = "2224", Numero = 4, TeamId = 2 });

        Courses.Add(new Course { Id = 1, Name = "Programacion I" });
        Courses.Add(new Course { Id = 2, Name = "Programacion III" });
        Courses.Add(new Course { Id = 3, Name = "Base de Datos" });

        Students.Add(new Student { Id = 1, Name = "Ana", Dni = "3333", File = "F-001", CourseId = 1 });
        Students.Add(new Student { Id = 2, Name = "Sofia", Dni = "3334", File = "F-002", CourseId = 1 });
        Students.Add(new Student { Id = 3, Name = "Diego", Dni = "3335", File = "F-003", CourseId = 2 });

        Activities.Add(new Activity { Id = 1, Title = "Parcial 1", Description = "Primer parcial", Date = DateTime.Now, Type = TypeActivity.Examen, CourseId = 1 });
        Activities.Add(new Activity { Id = 2, Title = "Clase 1", Description = "Introduccion", Date = DateTime.Now, Type = TypeActivity.Clase, CourseId = 1 });
        Activities.Add(new Activity { Id = 3, Title = "Taller de repaso", Description = "Repaso general", Date = DateTime.Now, Type = TypeActivity.Taller, CourseId = 2 });
    }
}
