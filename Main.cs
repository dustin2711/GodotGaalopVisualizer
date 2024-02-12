using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Godot;

// Run the benchmark
BenchmarkRunner.Run<InterpolatingTriangleBenchmark>();

/// <summary>
///   This class contains different methods to calculate the interpolating triangle from the Gaalop Web example.
/// </summary>
public class InterpolatingTriangleBenchmark
{
    const int IterationCount = 10;

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangleUsingArray()
    {
        (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingArray(0);
    }

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangleUsingArrayOutput()
    {
        (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingArrayOutput(0);
    }

    //[Benchmark]
    //[IterationCount(IterationCount)]
    //public void InterpolatingTriangleUsingArrayMaxima()
    //{
    //    (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingArrayMaxima(0);
    //}

    //[Benchmark]
    //[IterationCount(IterationCount)]
    //public void InterpolatingTriangleUsingArrayCSE()
    //{
    //    (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingArrayCSE(0);
    //}

    //[Benchmark]
    //[IterationCount(IterationCount)]
    //public void InterpolatingTriangleUsingArrayMaximaCSE()
    //{
    //    (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingArrayMaximaCSE(0);
    //}

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangleUsingTuple()
    {
        (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingTuple(0);
    }

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangleUsingVector3()
    {
        (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingVector3(0);
    }

    //[Benchmark]
    //[IterationCount(IterationCount)]
    //public void InterpolatingTriangleUsingVector3CSE()
    //{
    //    (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingVector3CSE(0);
    //}

    //[Benchmark]
    //[IterationCount(IterationCount)]
    //public void InterpolatingTriangleUsingVector3Maxima()
    //{
    //    (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingVector3Maxima(0);
    //}

    //[Benchmark]
    //[IterationCount(IterationCount)]
    //public void InterpolatingTriangleUsingVector3MaximaCSE()
    //{
    //    (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingVector3MaximaCSE(0);
    //}
}