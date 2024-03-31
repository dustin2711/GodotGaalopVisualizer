using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Godot;

//PolygonFromLineBuilder.DefaultNew(Line.LinePoints, Line.halfWidth);

// Run the benchmark
//BenchmarkRunner.Run<LinePolygonBenchmark>();
BenchmarkRunner.Run<InterpolatingTriangleBenchmark>();

public class LinePolygonBenchmark
{
    [Benchmark]
    public void PolygonFromLine_Legacy()
    {
        PolygonFromLineBuilder.Legacy(Line.LinePoints, Line.halfWidth);
    }

    [Benchmark]
    public void PolygonFromLine_LegacyOptimized()
    {
        PolygonFromLineBuilder.LegacyOptimized(Line.LinePoints, Line.halfWidth);
    }


    [Benchmark]
    public void PolygonFromLine_GaalopFirstTry()
    {
        PolygonFromLineBuilder.GaalopFirstTry(Line.LinePoints, Line.halfWidth);
    }


    [Benchmark]
    public void PolygonFromLine_GaalopOptimized()
    {
        PolygonFromLineBuilder.GaalopOptimized(Line.LinePoints, Line.halfWidth);
    }
}

/// <summary>
///   This class contains different methods to calculate the interpolating triangle from the Gaalop Web example.
/// </summary>
public class InterpolatingTriangleBenchmark
{
    const int IterationCount = 10;

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangle_Array()
    {
        (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingArray(0);
    }

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangle_ArrayPragmaOutput()
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
    public void InterpolatingTriangle_Tuple()
    {
        (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingTuple(0);
    }

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangle_Vector3()
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