using EmployeeManagement.ViewModels;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeViewModel> Create(EmployeeViewModel employee)
        {
            var newEmployee = new Employee
            {
                EmpNo = employee.EmpNo,
                EmpName = employee.EmpName,
                EmpAddressLine1 = employee.EmpAddressLine1,
                EmpAddressLine2 = employee.EmpAddressLine2,
                EmpAddressLine3 = employee.EmpAddressLine3,
                EmpDateOfJoin = employee.EmpDateOfJoin,
                EmpStatus = employee.EmpStatus,
                EmpImage = employee.EmpImage
            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            employee.Id = newEmployee.Id;
            return employee;
        }

        public async Task<bool> Delete(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            var employees =await _context.Employees
                .Select(e => new EmployeeViewModel(
                    e.Id,
                    e.EmpNo,
                    e.EmpName,
                    e.EmpAddressLine1,
                    e.EmpAddressLine2,
                    e.EmpAddressLine3,
                    e.EmpDateOfJoin,
                    e.EmpStatus,
                    e.EmpImage))
                .ToListAsync();

            return employees;
        }

        public async Task<EmployeeViewModel?> GetById(int id)
        {
            var employee = await _context.Employees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeViewModel(
                    e.Id,
                    e.EmpNo,
                    e.EmpName,
                    e.EmpAddressLine1,
                    e.EmpAddressLine2,
                    e.EmpAddressLine3,
                    e.EmpDateOfJoin,
                    e.EmpStatus,
                    e.EmpImage))
                .FirstOrDefaultAsync();

            return employee;
        }


       public async Task<EmployeeViewModel?> Update(int id, EmployeeUpdateViewModel employee)
        {
            var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (existingEmployee == null)
                return null;

            // map the only not null properties to existingEmployee
            if (employee.EmpNo != null)
                existingEmployee.EmpNo = employee.EmpNo;
            if (employee.EmpName != null)
                existingEmployee.EmpName = employee.EmpName;
            if (employee.EmpAddressLine1 != null)
                existingEmployee.EmpAddressLine1 = employee.EmpAddressLine1;
            if (employee.EmpAddressLine2 != null)
                existingEmployee.EmpAddressLine2 = employee.EmpAddressLine2;
            if (employee.EmpAddressLine3 != null)
                existingEmployee.EmpAddressLine3 = employee.EmpAddressLine3;
            if (employee.EmpDateOfJoin != null)
                existingEmployee.EmpDateOfJoin = (DateTime)employee.EmpDateOfJoin;
            if (employee.EmpStatus != null)
                existingEmployee.EmpStatus = (bool)employee.EmpStatus;
            if (employee.EmpImage != null)
                existingEmployee.EmpImage = employee.EmpImage;

            await _context.SaveChangesAsync();

            return new EmployeeViewModel(
                existingEmployee.Id,
                existingEmployee.EmpNo,
                existingEmployee.EmpName,
                existingEmployee.EmpAddressLine1,
                existingEmployee.EmpAddressLine2,
                existingEmployee.EmpAddressLine3,
                existingEmployee.EmpDateOfJoin,
                existingEmployee.EmpStatus,
                existingEmployee.EmpImage
                );

        }


    }
}
