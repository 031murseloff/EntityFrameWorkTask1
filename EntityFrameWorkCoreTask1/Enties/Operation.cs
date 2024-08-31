using System;
using System.Collections.Generic;

namespace EntityFrameWorkCoreTask1.Enties;

public partial class Operation 
{
    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}
