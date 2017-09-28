using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MSDNTask
{
    public class TaskTester
    {
        public Task<string> GetHtmlAsync()
        {
            // Execution is synchronous here
            var client = new HttpClient();

            return client.GetStringAsync("http://www.dotnetfoundation.org");
        }

        public async Task<string> GetFirstCharactersCountAsync(string url, int count)
        {
            // Execution is synchronous here
            var client = new HttpClient();

            // Execution of GetFirstCharactersCountAsync() is yielded to the caller here
            // GetStringAsync returns a Task<string>, which is *awaited*
            var page = await client.GetStringAsync("http://www.dotnetfoundation.org");

            // Execution resumes when the client.GetStringAsync task completes,
            // becoming synchronous again.

            if (count > page.Length)
            {
                return page;
            }
            else
            {
                return page.Substring(0, count);
            }
        }

        //public async Task<int> CalculateResult(InputData data)
        //{
        //    // This queues up the work on the threadpool.
        //    var expensiveResultTask = Task.Run(() => DoExpensiveCalculation(data));

        //    // Note that at this point, you can do some other work concurrently,
        //    // as CalculateResult() is still executing!

        //    // Execution of CalculateResult is yielded here!
        //    var result = await expensiveResultTask;

        //    return result;
        //}
    }
}
