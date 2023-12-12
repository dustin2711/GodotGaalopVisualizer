using Godot;
using System.Diagnostics;

public static class Watch
{
    private static readonly Stopwatch watch = new();

    public static float StopwatchTime => (float)watch.Elapsed.TotalMilliseconds;

    /// <summary>
    ///   Starts Helper-Stopwatch and returns elapsed millisecond since last start.
    /// </summary>
    public static void Start()
    {
        watch.Restart();
    }
	
    public static float StopStopwatch()
    {
        watch.Stop();
        return (float)watch.Elapsed.TotalMilliseconds;
    }

    public static void Log(string identifier = "Stopwatch")
    {
        GD.Print(identifier + ": " + watch.Elapsed.TotalMilliseconds.ToString("0.000") + " ms");
    }
}
