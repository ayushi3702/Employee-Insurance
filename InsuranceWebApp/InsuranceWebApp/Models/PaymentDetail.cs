using System;
using System.Collections.Generic;

namespace InsuranceWebApp.Models;

public partial class PaymentDetail
{
    public int PaymentId { get; set; }

    public int? EmpId { get; set; }

    public string? BankName { get; set; }

    public string? CardHolderName { get; set; }

    public string? CardNumber { get; set; }

    public string? CardExpiryDate { get; set; }

    public int? Cvv { get; set; }

    public virtual EmployeeDetail? Emp { get; set; }
}
