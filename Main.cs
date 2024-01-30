using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Godot;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting testing...");

        BenchmarkRunner.Run<InterpolatingTriangleTest>();

        Console.ReadLine();
    }
}

public class InterpolatingTriangleTest
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

    [Benchmark]
    [IterationCount(IterationCount)]
    public void InterpolatingTriangleUsingVector3Short()
    {
        (Vector3 a, Vector3 b, Vector3 c) = TriangleInterpolationManager.GetTriangleUsingVector3Short(0);
    }
}