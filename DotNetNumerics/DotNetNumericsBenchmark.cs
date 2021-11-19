using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Numerics;
using MathNet.Spatial.Euclidean;


namespace XTU.Benchmark.DotNetNumerics
{
    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class DotNetNumericsBenchmark
    {
        [Benchmark]
        public void RotateByNumerics()
        {
            var vector = new Vector3(10, 20, 30);
            var angle = MathNet.Spatial.Units.Angle.FromDegrees(0.5);
            var rotation = Matrix4x4.CreateFromAxisAngle(Vector3.One, (float)angle.Radians);
            for (int i = 0; i < 720; i++)
            {
                vector = Vector3.Transform(vector, rotation);
            }
        }

        [Benchmark]
        public void RotateByMathNet()
        {
            var vector = new Vector3D(10, 20, 30);
            var about = new Vector3D(1, 1, 1);
            var angle = MathNet.Spatial.Units.Angle.FromDegrees(0.5);

            for (int i = 0; i < 720; i++)
            {
                vector = vector.Rotate(about, angle);
            }
        }
    }
}