namespace MyModels;

public class Course
{
    public static IList<Course> All {get; set; }

    static Course()
    {
        All = new List<Course>()
        {
            new Course(){Id = 1, Title = "C#", Duration = 40, Description = "C# Intro"},
            new Course(){Id = 2, Title = "Git", Duration = 24, Description = "Git intro"},
            new Course(){Id = 3, Title = "ASP.NET Linux", Duration = 40, Description = "ASP.NET MVC for Linux"}
        };
    }

    public int Id { get; set;}
    public string Title { get; set;}
    public int Duration { get; set;}
    public string Description { get; set;}
}