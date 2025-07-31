using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkFlowDemo1
{
    public sealed class FileActivity_InputContent_Step2 : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> ContentArg { get; set; }

        public InArgument<string> FullPath { get; set; }
        public OutArgument<bool> IsSuccedArgs { get; set; }
        public int lineNumber { get; set; }

        public bool isSaveSuccess = true;
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            var text = context.GetValue(this.ContentArg);
            string filePath = context.GetValue(FullPath);
            try
            {
                //创建文件
                // 判断文件是否存在
                if (!File.Exists(filePath))
                {
                    // 文件不存在，创建文件并写入初始内容
                    lineNumber = 1;
                    File.WriteAllText(filePath, $"{lineNumber}. 这是文件的初始内容\n");
                    File.AppendAllText(filePath, text);
                    Console.WriteLine("文件已创建并写入初始内容");
                 
                }
                else
                {
                    // 文件存在，追加内容
                    // 文件存在，读取当前文件中的行数
                    var existingLines = File.ReadAllLines(filePath);
                    lineNumber = existingLines.Length + 1;  // 获取当前行数并递增
                    File.AppendAllText(filePath, $"{lineNumber}. {text}\n");
                    Console.WriteLine("内容已追加到现有文件");
              
                }

            }
            catch (Exception)
            {

                isSaveSuccess = false;
            }
            finally
            {
                context.SetValue(IsSuccedArgs,isSaveSuccess);
            }



        }
    }
}
