using System.Reflection;
using BenchmarkDotNet.Running;

namespace XTU.Benchmark
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(Assembly.GetAssembly(typeof(Program)))
                             .Run(args);
        }
    }
}