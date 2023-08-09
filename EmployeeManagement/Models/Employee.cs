using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
//     Create table work.employee(
// 	id 			int unique key auto_increment,
//     	empNo 			varchar(10) unique not null,
//     	empName 		varchar(100) not null,
//     	empAddressLine1	nvarchar(100) not null,
//     	empAddressLine2 	nvarchar(100), 
//     	empAddressLine3 	nvarchar(100),
//     	empDateOfJoin		datetime not null,
//     	empStatus		bool not null,
//     	empImage		longtext not null
// );

    [Index(nameof(EmpNo), IsUnique = true)]
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string EmpNo { get; set; }

        [Required]
        [StringLength(100)]
        public string EmpName { get; set; }

        [Required]
        [StringLength(100)]
        public string EmpAddressLine1 { get; set; }

        
        [StringLength(100)]
        public string? EmpAddressLine2 { get; set; }

        [StringLength(100)]
        public string? EmpAddressLine3 { get; set; }

        [Required]
        public DateTime EmpDateOfJoin { get; set; }

        [Required]
        public bool EmpStatus { get; set; }

        [Required]
        public string EmpImage { get; set; }
        
    }
}





