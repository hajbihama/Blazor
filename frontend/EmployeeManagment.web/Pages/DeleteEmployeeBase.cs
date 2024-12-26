using EmployeeManagment.web.Services;
using Microsoft.AspNetCore.Components;
using Models;

namespace EmployeeManagment.web.Pages
{
    public class DeleteEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            DepartmentId = Employee.DepartmentId.ToString();
            Departments = (await DepartmentService.GetDepartments()).ToList();
        }

        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavigationManager.NavigateTo("/EmployeeList");
        }
    }
}
