using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkFlowDemo1
{
    public sealed class FileActivity_CreateFile_Step1 : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> FileName { get; set; }

        public OutArgument<string> FullPath { get; set; }

        public InArgument<string> Content { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            string text = context.GetValue(this.FileName);
            string fullpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, text);
            context.SetValue(this.FullPath,fullpath);
        }
    }
}
