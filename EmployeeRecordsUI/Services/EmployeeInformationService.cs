using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Base;
using Newtonsoft.Json;

namespace EmployeeRecordsUI.Services
{
    public static class EmployeeInformationService
    {
        private static readonly HttpClient Client = new HttpClient();
        private const string Url = "http://localhost:50340/api/employee";

        public static BindingList<Employee> GetEmployeeInformation()
        {
            try
            {
                var response = Client.GetAsync(Url).Result;
                if (!response.IsSuccessStatusCode) return null;
                var response1 = response.Content.ReadAsStringAsync().Result;
                var listOfEmployees = JsonConvert.DeserializeObject<BindingList<Employee>>(response1);
                return listOfEmployees;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void CreateEmployee(RowObjectEventArgs e)
        {
            try
            {

                var employeeRecord = (Employee)e.Row;
                if (!string.IsNullOrEmpty(employeeRecord.FirstName) && !string.IsNullOrEmpty(employeeRecord.LastName))
                {
                    var message = CreateMessage(employeeRecord, HttpMethod.Post);
                    var response = Client.SendAsync(message).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Something went wrong with processing data!");
                    }
                }
                GetEmployeeInformation();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public static void UpdateEmployeeInformation(RowObjectEventArgs e)
        {
            try
            {

                var employeeRecord = (Employee)e.Row;
                if (!string.IsNullOrEmpty(employeeRecord.FirstName) && !string.IsNullOrEmpty(employeeRecord.LastName))
                {
                    var newUrl = "http://localhost:50340/api/employee/" + employeeRecord.Id;
                    var message = CreateMessage(employeeRecord, HttpMethod.Put);
                    message.RequestUri = new Uri(newUrl);
                    var response = Client.SendAsync(message).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Something went wrong with processing data!");
                    }
                }
                GetEmployeeInformation();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public static void DeleteEmployeeInformation(RowDeletedEventArgs e)
        {
            try
            {

                var employeeRecord = (Employee)e.Row;
                if (!string.IsNullOrEmpty(employeeRecord.FirstName) && !string.IsNullOrEmpty(employeeRecord.LastName))
                {
                    var message = CreateMessage(employeeRecord, HttpMethod.Delete);
                    var response = Client.SendAsync(message).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Something went wrong with processing data!");
                    }
                }
                GetEmployeeInformation();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private static HttpRequestMessage CreateMessage(Employee employeeRecord, HttpMethod method)
        {
            var message = new HttpRequestMessage(method, Url);
            message.Headers.Add("Accept", "application/json");
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            message.Content = new StringContent(JsonConvert.SerializeObject(employeeRecord), Encoding.UTF8, "application/json");
            return message;
        }
    }
}
