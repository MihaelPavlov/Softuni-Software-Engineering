using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //  GetEmployeesFullInformation(context));
            // GetEmployeesWithSalaryOver50000(context);
            // GetEmployeesFromResearchAndDevelopment(context);
            // AddNewAddressToEmployee(context);
            // GetEmployeesInPeriod(context);
            // GetAddressesByTown(context);
            // GetEmployee147(context);
            // GetDepartmentsWithMoreThan5Employees(context);
            //  GetLatestProjects(context);
            //IncreaseSalaries(context);
            //GetEmployeesByFirstNameStartingWithSa(context);
            //DeleteProjectById(context);
            //RemoveTown(context)
        }


        //problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees.OrderBy(x => x.EmployeeId).ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithSalary = context.Employees.OrderByDescending(e => e.Salary)
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var e in employeesWithSalary)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:F2}");
            }
            return sb.ToString().TrimEnd();

        }

        //problem 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.
                Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,

            };
            var nakovName = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            context.Addresses.Add(newAddress);

            nakovName.Address = newAddress;
            context.SaveChanges();
            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(employee);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();


            var employees = context.Employees.Where
                (e => e.EmployeesProjects.
                Any(ep => ep.Project.StartDate.Year >= 2001
                     && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ?
                        ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished"
                    })
                }).ToList();
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();



        }

        //problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var address = context.Addresses
                .OrderByDescending(a => a.Employees.Where(e => e.AddressId == a.AddressId).Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Where(e => e.AddressId == a.AddressId).Count()
                })
                .ToList();

            foreach (var a in address)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
        //problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    project = e.EmployeesProjects.Select(ep => new
                    {
                        ep.Project
                    }).OrderBy(ep => ep.Project.Name).ToList()
                }).ToList();


            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                foreach (var p in e.project)
                {

                    sb.AppendLine(p.Project.Name);
                }

            }
            return sb.ToString().TrimEnd();

        }

        //problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)

        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments.Where(d => d.Employees.Count() > 5)
                  .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    d.Manager.FirstName,
                    d.Manager.LastName,
                    DepEmployees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList()
                })
                .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.FirstName} {d.LastName}");

                foreach (var depEmployee in d.DepEmployees)
                {
                    sb.AppendLine($"{depEmployee.FirstName} {depEmployee.LastName} - {depEmployee.JobTitle}");
                }
            }


            return sb.ToString().TrimEnd();
        }

        //problem 11 
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var lastProjects = context.Projects.OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                 .OrderBy(p => p.Name)
                .ToList();
            foreach (var project in lastProjects)
            {
                sb.AppendLine($"{project.Name}")
                .AppendLine($"{project.Description}")
                .AppendLine($"{project.StartDate}");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesForIncrease = context.Employees.
                Where(e => e.Department.Name == "Engineering" ||
                        e.Department.Name == "Tool Design" ||
                        e.Department.Name == "Marketing" ||
                        e.Department.Name == "Information Services");

            foreach (var e in employeesForIncrease)
            {
                e.Salary += e.Salary * 0.12M;
            }


            context.SaveChanges();

            var employeesInfo = employeesForIncrease.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

            foreach (var e in employeesInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithSa = context.Employees.Where(e => e.FirstName.StartsWith("Sa") || e.FirstName.StartsWith("SA"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList();

            foreach (var e in employeesWithSa)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }


        //problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();


            var employeeProject = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);

            foreach (var ep in employeeProject)
            {
                context.EmployeesProjects.Remove(ep);
            }
            var projectForDeleteIt = context.Projects.FirstOrDefault(e => e.ProjectId == 2);
            context.Projects.Remove(projectForDeleteIt);



            context.SaveChanges();

            var get10Project = context.Projects.Take(10).Select(p => new
            {
                p.Name
            }).ToList();

            foreach (var p in get10Project)
            {
                sb.AppendLine($"{p.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 15

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var townToDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            var addressToDelete = context.Addresses.Where(a => a.TownId == townToDelete.TownId);


            int addressCount = addressToDelete.Count();

       
            var employeeToDeleteAddress = context.Employees.Where(e => addressToDelete.Any(a => a.AddressId == e.AddressId));
         


            foreach (var e in employeeToDeleteAddress)
            {
                e.AddressId = null;
            }
            foreach (var a in addressToDelete)
            {
                context.Addresses.Remove(a);
            }
            context.Towns.Remove(townToDelete);

            context.SaveChanges();




            return $"{addressCount} addresses in Seattle were deleted";
           
       
        }
    }
}
