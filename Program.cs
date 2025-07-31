using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎使用FileWorkFlow。。。");

            // 创建工作流实例
            var fileWorkFlow = new Activity1();
            var output = WorkflowInvoker.Invoke(fileWorkFlow, new Dictionary<string, object>
            {
                { "FileNameArg", "test.txt" },
                { "ContentArg", "这是一个测试文件的内容。" }
            });
            output.TryGetValue("FullPathArg", out object fullPath);
            //WorkflowInvoker.Invoke(new FileActivity_CreateFile_Step1(), new Dictionary<string, object>
            //{
            //    { "FileName", "test.txt" },
            //    { "Content", "这是一个测试文件的内容。" }
            //});
            Console.WriteLine($"FilePath:{fullPath}");
            Console.WriteLine("结束使用FileWorkFlow。。。");
            Console.ReadLine();
        }
    }
}
