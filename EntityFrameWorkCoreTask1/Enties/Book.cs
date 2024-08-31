
using System;
using System.Collections.Generic;

namespace EntityFrameWorkCoreTask1.Enties;

public partial class Book 
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? PageCount { get; set; }

    public int AuthorId { get; set; }

    public int BookTypeId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<BookStudent> BookStudents { get; set; } = new List<BookStudent>();

    public virtual BookType BookType { get; set; } = null!;
}
