using System;
using System.Collections.Generic;

namespace Giaolang.EmployeeManagement.DAL.Entities;

public partial class EmployeeRecord
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? HireDate { get; set; }
}
