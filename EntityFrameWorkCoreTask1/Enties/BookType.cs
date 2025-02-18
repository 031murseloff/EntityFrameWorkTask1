﻿
using System;
using System.Collections.Generic;

namespace EntityFrameWorkCoreTask1.Enties;

public partial class BookType 
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
