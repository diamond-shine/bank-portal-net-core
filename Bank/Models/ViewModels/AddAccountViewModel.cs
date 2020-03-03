using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models.ViewModels
{
    public class AddAccountViewModel
    {
        [BindNever]
        public IEnumerable<Bankemployee> Employees { get; set; }
        [BindNever]
        public IEnumerable<Accounttypes> AccountTypes { get; set; }
        [BindNever]
        public IEnumerable<Bankbranch> Branches { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [RegularExpression(@"^\d+(?:\.\d{1,2})?$")]
        public decimal InitialAmount { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int BranchId { get; set; }
        [Required]
        public int AccountType { get; set; }
    }
}
