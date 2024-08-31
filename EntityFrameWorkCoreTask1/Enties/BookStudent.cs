using System;
using System.Collections.Generic;

namespace EntityFrameWorkCoreTask1.Enties;

public partial class BookStudent 
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int StudentId { get; set; }

    public virtual Student Book { get; set; } = null!;

    public virtual Book Student { get; set; } = null!;
}
