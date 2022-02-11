using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async void Main(string[] args)
        {
            /*Console.WriteLine("Code 1");
            Thread x = new Thread(SomeMethod);
            x.Start();
            Console.WriteLine("Code 2");
            Console.Read();*/


            Task<string> getDataTask = Task.Factory.StartNew(() => { return GetData(); });
            Task<string> processDataTask = getDataTask.ContinueWith((data) => { return ProcessData(data); });
            Task saveDataTask = processDataTask.ContinueWith((pData) => { SaveData(pData); });
            Task<string> displayDataTask = processDataTask.ContinueWith((pData) => { return CreateDisplayString(pData); });*/
            Console.WriteLine(displayDataTask.Result);
            saveDataTask.Wait();

            Task<string> getDataTaskAsync = GetDataAsync();
            Task<string> processDataTaskAsync = ProcessDataAsync(getDataTaskAsync);
            _ = SaveDataAsync(processDataTaskAsync);
            Task<string> displayDataTaskAsync = CreateDisplayStringAsync(processDataTaskAsync);
            Console.WriteLine(displayDataTaskAsync.Result);
           
            
            Console.WriteLine("I am not dependent");
            
            /*Console.WriteLine("1");
            SomeMethod();
            Console.WriteLine("I am not dependent");*/

            Console.Read();
        }

        private static async Task<string> CreateDisplayStringAsync(Task<string> pData)
        {
            await Task.Delay(60000);
            return "This the display Sting: " + pData.Result;
        }

        private static async Task SaveDataAsync(Task<string> pData)
        {
            await Task.Delay(20000);
            Console.WriteLine("Data Saved");
        }

        private static async Task<string> ProcessDataAsync(Task<string> data)
        {
            await Task.Delay(5000);
            Console.WriteLine("Data Processed");
            return "Processed_" + data.Result;
        }

        private static async Task<string>  GetDataAsync()
        {
            Console.WriteLine("Getting Data");
            await Task.Delay(5000);
            return "List of data";
        }

        private static string CreateDisplayString(Task<string> pData)
        {
            Task.Delay(60000).Wait();
            return "This the display Sting: " + pData.Result;
        }

        private static void SaveData(Task<string> pData)
        {
            Task.Delay(20000).Wait();
            Console.WriteLine("Data Saved");
        }

        private static string ProcessData(Task<string> data)
        {
            Task.Delay(5000).Wait();
            Console.WriteLine("Data Processed");
            return "Processed_" + data.Result;
        }

        private static string GetData()
        {
            Console.WriteLine("Getting Data");
            Task.Delay(5000).Wait();
            return "List of data";
        }
        private static async void SomeMethod()
        {
            Console.WriteLine("Code 2");
            await Task.Delay(20000);
            Console.WriteLine("Code 3");
        }
    }
}
