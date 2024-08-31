using System;
using System.Collections.Generic;

namespace EntityFrameWorkCoreTask1.Enties;

public partial class Student 
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int SchoolNumber { get; set; }

    public byte Gender { get; set; }

    public DateOnly BirthDay { get; set; }

    public long PhoneNumber { get; set; }

    public virtual ICollection<BookStudent> BookStudents { get; set; } = new List<BookStudent>();
}
