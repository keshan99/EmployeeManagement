using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        // Create a new employee
        Task<EmployeeViewModel> Create(EmployeeViewModel employee);

        // Retrieve all employees
        Task<IEnumerable<EmployeeViewModel>> GetAll();

        // Retrieve a specific employee by ID
        Task<EmployeeViewModel?> GetById(int id);

        // Update an existing employee
        Task<EmployeeViewModel?> Update(int id, EmployeeUpdateViewModel employee);

        // Delete an employee by ID
        Task<bool> Delete(int id);
    }
}