using System;
using System.Collections.Generic;

namespace InsuranceWebApp.Models;

public partial class PolicyDetail
{
    public int PolicyId { get; set; }

    public int? EmpId { get; set; }

    public string? Insurer { get; set; }

    public string? Tpa { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? CoverageType { get; set; }

    public string? PolicyStatus { get; set; }

    public string? BeneficiaryName { get; set; }

    public string? BeneficiaryRelation { get; set; }

    public virtual EmployeeDetail? Emp { get; set; }
}
