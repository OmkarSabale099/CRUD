using System;
using System.Collections.Generic;

namespace CRUDApplication.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Mob { get; set; } = null!;

    public string Desgnation { get; set; } = null!;
}
