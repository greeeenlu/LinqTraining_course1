using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LinqSample.WithoutLinq;
using LinqSample.YourOwnLinq;
using NUnit.Framework;

namespace LinqTests
{
    [TestFixture]
    public class LinqTest
    {
        [Test]
        public void find_products_that_price_between_200_and_500()
        {
            var products = RepositoryFactory.GetProducts().ToList();
            var actual = WithoutLinq.find(products);
            var expected = new List<Product>()
            {
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void find_products_that_price_between_200_and_500_and_cost_more_than_30()
        {
            var products = RepositoryFactory.GetProducts();
            var actual = WithoutLinq.Find(products, p => p.Price > 200 && p.Price < 500 && p.Cost > 30);
            var expected = new List<Product>()
            {
                //new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void find_employee_that_age_more_30_item_index_more_2()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.Find<Employee>((e, index) => e.Age > 30 && index >= 2);
            var expected = new List<Employee>()
            {
                //new Employee {Name = "Joe", Role = RoleType.Engineer, MonthSalary = 100, Age = 44, WorkingYear = 2.6},
                //new Employee {Name = "Tom", Role = RoleType.Engineer, MonthSalary = 140, Age = 33, WorkingYear = 2.6},
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                //new Employee {Name = "Andy", Role = RoleType.OP, MonthSalary = 80, Age = 22, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
                //new Employee {Name = "Mary", Role = RoleType.OP, MonthSalary = 180, Age = 26, WorkingYear = 2.6},
                //new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void YourWhere_YourSelect()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.
                    YourWhere(e => e.Age < 25).
                    YourSelect(e => $"{e.Role}:{e.Name}");

            var expected = new List<string>()
            {
                "OP:Andy",
                "Engineer:Frank",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void Take()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.YourTake(2);
            var expected = new List<Employee>
            {
                new Employee {Name = "Joe", Role = RoleType.Engineer, MonthSalary = 100, Age = 44, WorkingYear = 2.6},
                new Employee {Name = "Tom", Role = RoleType.Engineer, MonthSalary = 140, Age = 33, WorkingYear = 2.6},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void Skip()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.YourSkip(6);
            var expected = new List<Employee>
            {
                new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void TakeWhile()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.YourTakeWhile(2, e => e.MonthSalary > 150);
            var expected = new List<Employee>
            {
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
            };
            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]
        [Test]
        public void SkipWhile()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.YourSkipWhile(3, e => e.MonthSalary < 150);
            var expected = new List<Employee>
            {
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
                new Employee {Name = "Mary", Role = RoleType.OP, MonthSalary = 180, Age = 26, WorkingYear = 2.6},
                new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };
            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }
    }
}