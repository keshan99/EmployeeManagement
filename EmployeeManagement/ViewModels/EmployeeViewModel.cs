using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeViewModel
    {
        public int? Id { get; set; }

        [Required]
        public string EmpNo { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public string EmpAddressLine1 { get; set; }

        public string? EmpAddressLine2 { get; set; }

        public string? EmpAddressLine3 { get; set; }

        [Required]
        public DateTime EmpDateOfJoin { get; set; }

        [Required]
        public bool EmpStatus { get; set; }

        [Required]
        public string EmpImage { get; set; }

        public EmployeeViewModel(int? id, string empNo, string empName, string empAddressLine1, string? empAddressLine2, string? empAddressLine3, DateTime empDateOfJoin, bool empStatus, string empImage)
        {
            Id = id;
            EmpNo = empNo;
            EmpName = empName;
            EmpAddressLine1 = empAddressLine1;
            EmpAddressLine2 = empAddressLine2;
            EmpAddressLine3 = empAddressLine3;
            EmpDateOfJoin = empDateOfJoin;
            EmpStatus = empStatus;
            EmpImage = empImage;
        }
    }
}