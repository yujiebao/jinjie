#define unity 
#define CSharp
namespace 预处理器指令
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 知识点一 什么是编译器
            //编译器是一种翻译程序
            //它用于将源语言程序翻译为目标语言程序
            //源语言程序:某种程序设计语言写成的,比如C#、C、C++、Java等语言写的程序
            //目标语言程序:二进制数表示的伪机器代码写的程序
            #endregion

            #region 知识点二 什么是预处理器指令
            //预处理器指令 指导编译器 在实际编译开始之前对信息进行预处理
            //预处理器指令 都是以#开始
            //预处理器指令不是语句，所以临们不以分号;结束
            //目前我们经常用到的 折叠代码块 就是预处理器指令
            #endregion

            #region 知识点三 常见的预处理器指令
            //1
            //#define
            //定义一个符号，类似一个没有值的变量
            //#undef
            //取消define定义的符号，让其失效
            //两者都是写在脚本文件最前面
            //一般配合 if指令使用 或配合特性

            //2
            //#if
            //#elif
            //#else
            //#endif
            //和if语句规则一样
            //一般配合#define定义的符号使用
            //用于告诉编译器进行编译代码的流程控制

#if unity &&CSharp //如果发现unity这个符号定义了   那么就执行下面的代码
            Console.WriteLine("unity & C#");
#endif

            //3
            //#warning
            //#error
            //告诉编译器
            //是报警告还是报错误
            //一般还是配合if使用
            #endregion
        }
    }
}