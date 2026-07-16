P01_StudentSystem
├── Data
│ └── StudentSystemContext.cs
├── Models
│ ├── Student.cs
│ ├── Course.cs
│ ├── Resource.cs
│ ├── HomeworkSubmission.cs
│ ├── StudentCourse.cs
│ └── Enums.cs
└── Program

namespace P01_StudentSystem.Models
{
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }

    public enum ContentType
    {
        Application,
        Pdf,
        Zip
    }
}

