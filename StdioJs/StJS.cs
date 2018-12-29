using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.CodeDom.Compiler;

namespace StdioJs
{
    public class StJS
    {
        private Dictionary<string, Type> msjsAssemblyTypeList = new Dictionary<string, Type>();
        /// <summary>
        /// 运行脚本
        /// </summary>
        /// <param name="scriptCode"></param>
        /// <returns></returns>
        public object RunByJSCodeProvider(string scriptCode)
        {
            string md5 = DevCommon.MD5GenerateHashString(scriptCode);
            if (this.msjsAssemblyTypeList.ContainsKey(md5))
            {
                Type _evaluateType = this.msjsAssemblyTypeList[md5];
                object obj = _evaluateType.InvokeMember("JsRun", BindingFlags.InvokeMethod,
                        null, null, null);
                return obj;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("package Stdio{");
                sb.Append(" public class JScript {");
                sb.Append("     public static function JsRun() {");
                sb.Append(scriptCode);
                sb.Append("     }");
                sb.Append(" }");
                sb.Append("}");

                CompilerParameters parameters = new CompilerParameters();

                parameters.GenerateInMemory = true;

                CodeDomProvider _provider = new Microsoft.JScript.JScriptCodeProvider();

                CompilerResults results = _provider.CompileAssemblyFromSource(parameters, sb.ToString());

                Assembly assembly = results.CompiledAssembly;

                Type _evaluateType = assembly.GetType("Stdio.JScript");

                this.msjsAssemblyTypeList.Add(md5, _evaluateType);

                object obj = _evaluateType.InvokeMember("JsRun", BindingFlags.InvokeMethod,
                null, null, null);

                return obj;
            }
        }

    }
}
