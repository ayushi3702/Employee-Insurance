using System;
using System.Collections.Generic;

namespace InsuranceWebApp.Models;

public partial class UserLoginDetail
{
    public int? EmpId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual EmployeeDetail? Emp { get; set; }
}
