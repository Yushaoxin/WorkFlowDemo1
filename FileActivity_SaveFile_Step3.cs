using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowDemo1
{
    public sealed class FileActivity_SaveFile_Step3 : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<bool> IsSuccedArgs { get; set; }
        public InArgument<string> FullPath { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            var result = context.GetValue(this.IsSuccedArgs);
            var fullPath = context.GetValue(this.FullPath);
            Console.WriteLine($"保存文件结果：{result}");
        }
    }
}
