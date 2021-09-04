### ASP.NET Framework Practice

## Environment
- Windows 10
- Visual studio 2019 Community
- ASP.NET Framework 4.7.2

## Setting
- Project Build : ASP.NET Web Application(.NET framework)
- Controller Build : Web Api2 (Empty Scaffolder)

## Used thrid-party lib
- Newtonsoft.Json (v12.0.2) - json
- Unity (v5.11.10) - DI framework
- xunit (v2.4.1) - unit test framework
- log4net (v2.0.12) - logging

## Unit testing
1. Install Extension
    - Explorer xunit.net.TestGenerator
    - Restart visual studio
    - You can generate test code. (right click on target class.)

2. Example
```cs
using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace DemoWebApiTests
{
    public class UnitTests
    {
        private readonly ITestOutputHelper output;

        public UnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact()]
        public void Test()
        {
            var product = new Product()
            {
                productId = 999,
                name = "test",
                category = "TEST",
                price = 10
            };
            output.WriteLine(product.ToString());

            var isValid = product.name == "test";
            Assert.True(isValid, $"product is not valid");
        }

        internal static Task<int> SumAsync(int first, int last)
        {
            // async method
            return Task.Run(() =>
            {
                int s = 0;
                for (int i = first; i <= last; i++)
                {
                    s += i;
                    Thread.Sleep(100);
                };
                return s;
            });
        }

        [Fact()]
        public void TaskTest()
        {
            Task<int> task = SumAsync(1, 10);
            output.WriteLine($"{task.Result}"); // blocking
            output.WriteLine("started.");
            Assert.True(true, $"product is not valid");
        }

        [Fact()]
        public void TaskTest2()
        {
            Task<int> task = SumAsync(1, 10);

            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                output.WriteLine($"{awaiter.GetResult()}"); // non blocking, but not shown in Test Detail Summary
                Assert.True(true, $"product is not valid");
            });
            output.WriteLine("started.");
        }

        internal static async Task ShowResult()
        {
            // async - await code sample
            int ret = await SumAsync(1, 10);
            Console.WriteLine($"{ret}");
        }

        [Fact()]
        public void TaskTest3()
        {
            Task t = ShowResult();
            t.Wait();
            output.WriteLine("started.");
            Assert.True(true, $"product is not valid");
        }
    }
}

```