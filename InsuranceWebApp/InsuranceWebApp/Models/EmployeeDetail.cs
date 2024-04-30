using System;
using System.Collections.Generic;

namespace InsuranceWebApp.Models;

public partial class EmployeeDetail
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

    public virtual ICollection<PolicyDetail> PolicyDetails { get; set; } = new List<PolicyDetail>();
}
