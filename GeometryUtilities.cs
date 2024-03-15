using Godot;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

public static class GeometryUtilities
{
    public const double EPS = 1e-6;

    /// <summary>
    /// Calculates the euclidean distance between two points given by their respective position in x,y coordinates
    /// </summary>
    /// <param name="x1">X-Coordinate of first point</param>
    /// <param name="y1">Y-Coordinate of first point</param>
    /// <param name="x2">X-Coordinate of second point</param>
    /// <param name="y2">Y-Coordinate of second point</param>
    /// <returns>Returns the euclidean distance between both points</returns>
    public static float EuclideanDistance(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
    }

    /// <summary>
    /// Calculates the euclidean distance between two points given by their respective position as <see cref="Vector2"/>
    /// </summary>
    /// <param name="p1">Position of first point</param>
    /// <param name="p2">Position of second point</param>
    /// <returns>Returns the euclidean distance between both points</returns>
    public static float EuclideanDistance(Vector2 p1, Vector2 p2)
    {
        return Mathf.Sqrt(((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));
    }

    /// <summary>
    /// Determines if point <paramref name="point"/> is left of the
    /// linesegment defined <paramref name="start"/> and <paramref name="end"/>
    /// </summary>
    /// <param name="start">Start of the line segment</param>
    /// <param name="end">End of the line segment</param>
    /// <param name="point">Point to check</param>
    /// <returns>Returns true if point is to the left of the line segment</returns>
    public static bool IsPointLeftOfLineSegment(Vector2 start, Vector2 end, Vector2 point)
    {
        return (((end.X - start.X) * (point.Y - start.Y)) - ((end.Y - start.Y) * (point.X - start.X))) > 0;
    }

    public static Vector2? LineSegmentIntersectionEndless(Vector2 line1Start, Vector2 line1End, Vector2 line2Start, Vector2 line2End)
    {
        Vector2 deltaLine1 = line1End - line1Start;
        Vector2 deltaLine2 = line2End - line2Start;

        return LineSegmentIntersection(
            line1Start - 10000 * deltaLine1, line1End + 10000 * deltaLine1,
            line2Start - 10000 * deltaLine2, line2End + 10000 * deltaLine2);
    }

    public static Vector2? LineSegmentIntersectionDirection(Vector2 startA, float orientationA, Vector2 startB, float orientationB)
    {
        Vector2? value = LineSegmentIntersectionEndless(
            startA, startA.MoveInDirection(1, orientationA),
            startB, startB.MoveInDirection(1, orientationB));
        return value;
    }

    /// <summary>
    ///   Finds the intersection of a line with another line.
    /// </summary>
    public static Vector2 FindLineIntersection(Vector2 firstPoint, float firstDirection, Vector2 secondPoint, float secondDirection)
    {
        return (Vector2)LineSegmentIntersectionEndless(
            firstPoint, firstPoint.MoveInDirection(1, firstDirection),
            secondPoint, secondPoint.MoveInDirection(1, secondDirection));

        // Calculate the direction vectors of the lines
        Vector2 firstVector = new Vector2(MathF.Cos(firstDirection), MathF.Sin(firstDirection));
        Vector2 secondVector = new Vector2(MathF.Cos(secondDirection), MathF.Sin(secondDirection));

        // Calculate the intersection point using parametric form
        float t = (secondPoint.X * firstVector.Y - firstPoint.X * firstVector.Y + firstVector.X * firstPoint.Y - secondVector.X * secondPoint.Y) /
                  (secondVector.X * firstVector.Y - firstVector.X * secondVector.Y);
        Vector2 intersection = new Vector2(firstPoint.X + t * firstVector.X, firstPoint.Y + t * firstVector.Y);

        return intersection;
    }

    public static Vector2? LineSegmentIntersectionDirection(Vector2 startA, Vector2 directionA, Vector2 startB, Vector2 directionB)
    {
        return LineSegmentIntersection(
            startA - 10000 * directionA, startA + 10000 * directionA,
            startB - 10000 * directionB, startA + 10000 * directionB);
    }

    /// <summary>
    /// Calculates the point of intersection of two line segments. If no intersections are exist returns null.
    /// </summary>
    /// <param name="line1Start">Start of the first line segment</param>
    /// <param name="line1End">End of the first line segment</param>
    /// <param name="line2Start">Start of the second line segment</param>
    /// <param name="line2End">End of the second line segment</param>
    /// <returns>Returns the point of intersection or null if no intersection exists</returns>
    public static Vector2? LineSegmentIntersection(Vector2 line1Start, Vector2 line1End, Vector2 line2Start, Vector2 line2End)
    {
        Vector2? res = null; // null means no intersection
        var denom = ((line2End.Y - line2Start.Y) * (line1End.X - line1Start.X)) - ((line2End.X - line2Start.X) * (line1End.Y - line1Start.Y));
        if (Mathf.Abs(denom) < EPS)
        { // Lines are parallel.
            return res;
        }
        var ua = (((line2End.X - line2Start.X) * (line1Start.Y - line2Start.Y)) - ((line2End.Y - line2Start.Y) * (line1Start.X - line2Start.X))) / denom;
        var ub = (((line1End.X - line1Start.X) * (line1Start.Y - line2Start.Y)) - ((line1End.Y - line1Start.Y) * (line1Start.X - line2Start.X))) / denom;
        if (ua >= 0.0 && ua <= 1.0 && ub >= 0.0 && ub <= 1.0)
        {
            // Get the intersection point.
            res = new Vector2(line1Start.X + (ua * (line1End.X - line1Start.X)), line1Start.Y + (ua * (line1End.Y - line1Start.Y)));
        }
        return res;
    }

    public static bool IsPolygonClockwise(IList<Vector2> points)
    {
        int count = points.Count();
        float sum = 0;
        for (int i = 0; i < count; i++)
        {
            Vector2 v1 = points[i];
            Vector2 v2 = points[(i + 1) % count];
            sum += (v2.X - v1.X) * (v2.Y + v1.Y);
        }
        return sum > 0;
    }

    public static float GetPolygonArea(List<Vector2> points)
    {
        if (points.Count < 3)
        {
            return 0;
        }

        bool firstPointEqualsLast = points.First() == points.Last();

        if (!firstPointEqualsLast)
        {
            points.Add(points[0]);
        }

        float area = (float)Mathf.Abs(points.Take(points.Count - 1)
           .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
           .Sum() / 2);

        if (!firstPointEqualsLast)
        {
            points.RemoveAt(points.Count - 1);
        }

        return area;
    }


    /// <summary>
    /// Calculates all intersections of two polylines <paramref name="line1"/> and <paramref name="line2"/>. If no
    /// intersections exist returns an empty list.
    /// </summary>
    /// <param name="line1">First polyline</param>
    /// <param name="line2">Second polyline</param>
    /// <returns>Returns the points of intersection of empty list if no intersections exist</returns>
    public static List<Vector2> LineLineIntersections(List<Vector2> line1, List<Vector2> line2)
    {
        var res = new List<Vector2>();

        for (int i = 0; i < line2.Count - 1; i++)
        {
            for (int j = 0; j < line1.Count - 1; j++)
            {
                var intRes = LineSegmentIntersection(line2[i], line2[i + 1], line1[j], line1[j + 1]);
                if (intRes.HasValue)
                {
                    res.Add(intRes.Value);
                }
            }
        }

        return res;
    }

    /// <summary>
    /// Calculates the closest distance between the point <paramref name="pt"/> and a linesegment
    /// given by the two points <paramref name="p1"/> and <paramref name="p2"/>. Also returns the
    /// coordinates of the closest point <paramref name="closest"/> and the normalized line
    /// parameter of the closest point <paramref name="lambda"/>.
    /// </summary>
    /// <param name="pt">Point to calculate the distance to</param>
    /// <param name="p1">First point of the line segment</param>
    /// <param name="p2">Second point of the line segment</param>
    /// <param name="closest">Closest point</param>
    /// <param name="lambda">
    /// Normalized line parameter. A value between 0 and 1 indicates that the closest point is
    /// orthogonal to the line segment
    /// </param>
    /// <returns>Returns the closest distance</returns>
    public static float DistanceToLineSegment(
        Vector2 pt, Vector2 p1, Vector2 p2, out Vector2 closest, out float lambda)
    {
        float dx = p2.X - p1.X;
        float dy = p2.Y - p1.Y;
        if ((dx == 0) && (dy == 0))
        {
            // It's a point not a line segment.
            closest = p1;
            dx = pt.X - p1.X;
            dy = pt.Y - p1.Y;
            lambda = 0;
            return Mathf.Sqrt(dx * dx + dy * dy);
        }

        // Calculate the t that minimizes the distance.
        float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) /
            (dx * dx + dy * dy);

        // See if this represents one of the segment's
        // end points or a point in the middle.
        if (t < 0)
        {
            closest = p1;
            dx = pt.X - p1.X;
            dy = pt.Y - p1.Y;
        }
        else if (t > 1)
        {
            closest = p2;
            dx = pt.X - p2.X;
            dy = pt.Y - p2.Y;
        }
        else
        {
            closest = new Vector2(p1.X + t * dx, p1.Y + t * dy);
            dx = pt.X - closest.X;
            dy = pt.Y - closest.Y;
        }

        lambda = t;
        return Mathf.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// Calculates all intersections of a polygon <paramref name="polygonPoint"/> and a polyline <paramref name="linePoints"/>.
    /// If no intersections exist returns an empty list.
    /// </summary>
    /// <param name="polygonPoint">Polygon</param>
    /// <param name="linePoints">Polyline</param>
    /// <returns>Returns the points of intersection of empty list if no intersections exist</returns>
    public static List<Vector2> PolygonLineIntersections(IList<Vector2> polygonPoint, IList<Vector2> linePoints)
    {
        var intersections = new List<Vector2>();

        for (int polyIndex = 0; polyIndex < polygonPoint.Count; polyIndex++)
        {
            for (int lineIndex = 0; lineIndex < linePoints.Count - 1; lineIndex++)
            {
                Vector2? intersection = LineSegmentIntersection(
                    polygonPoint[polyIndex], polygonPoint[(polyIndex + 1) % polygonPoint.Count],
                    linePoints[lineIndex], linePoints[lineIndex + 1]);
                if (intersection.HasValue && !intersections.Any(i => i.ValueEquals(intersection.Value, 0.0000001f)))
                {
                    intersections.Add(intersection.Value);
                }
            }
        }

        return intersections;
    }

    /// <summary>
    /// Checks if any of the given <paramref name="points"/>, e.g. from a polygon, is in the <paramref name="polygonPoints"/>.
    /// </summary>
    /// <param name="points"></param>
    /// <param name="polygonPoints"></param>
    /// <returns></returns>
    public static bool IsAnyPointInPolygon(IList<Vector2> points, IList<Vector2> polygonPoints)
    {
        foreach (Vector2 pt in points)
        {
            if (IsPointInPolygon(pt, polygonPoints))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    ///   Determines if the given point is inside the polygon.
    /// <paramref name="point"/>.
    /// </summary>
    /// <param name="point">Point to check</param>
    /// <param name="polygonPoints">Polygon</param>
    public static bool IsPointInPolygon(Vector2 point, IList<Vector2> polygonPoints)
    {
        bool result = false;
        int j = polygonPoints.Count - 1;
        for (int i = 0; i < polygonPoints.Count; i++)
        {
            if ((polygonPoints[i].Y < point.Y && polygonPoints[j].Y >= point.Y) || (polygonPoints[j].Y < point.Y && polygonPoints[i].Y >= point.Y))
            {
                if (polygonPoints[i].X + ((point.Y - polygonPoints[i].Y) / (polygonPoints[j].Y - polygonPoints[i].Y) * (polygonPoints[j].X - polygonPoints[i].X)) < point.X)
                {
                    result = !result;
                }
            }
            j = i;
        }
        return result;
    }

    /// <summary>
    ///   Calculates the total length of a pointlist.
    /// </summary>
    public static float CalcTotalLength(List<Vector2> points)
    {
        if (points.Count < 2)
        {
            return 0;
        }
        else
        {
            float length = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                length += (points[i + 1] - points[i]).Length();
            }
            return length;
        }
    }

    /// <summary>
    /// Determines if two lines each given by a linesegment intersect. Returns true if the lines intersect.
    /// </summary>
    /// <param name="pointsA">First linesegment</param>
    /// <param name="pointsB">Second linesegment</param>
    /// <exception cref="ArgumentException"/>
    /// <returns>Returns true if the two lines intersect</returns>
    public static bool LinesIntersect(List<Vector2> pointsA, List<Vector2> pointsB)
    {
        if (pointsA.Count != 2)
            throw new ArgumentException("l1 is not a linesegment", nameof(pointsA));
        if (pointsB.Count != 2)
            throw new ArgumentException("l2 is not a linesegment", nameof(pointsB));
        return LinesIntersect(pointsA[0], pointsA[1], pointsB[0], pointsB[1]);
    }

    // Taken from https://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
    /// <summary>
    /// Determines if two lines each given by two of its points intersect. Returns true if the lines intersect.
    /// </summary>
    /// <param name="p1">First point of the first line</param>
    /// <param name="q1">Second point of the first line</param>
    /// <param name="p2">First point of the second line</param>
    /// <param name="q2">Second point of the second line</param>
    /// <returns>Returns true if the two lines intersect</returns>
    public static bool LinesIntersect(Vector2 p1, Vector2 q1, Vector2 p2, Vector2 q2)
    {
        // Find the four orientations needed for general and
        // special cases
        int o1 = Orientation(p1, q1, p2);
        int o2 = Orientation(p1, q1, q2);
        int o3 = Orientation(p2, q2, p1);
        int o4 = Orientation(p2, q2, q1);

        // General case
        if (o1 != o2 && o3 != o4)
            return true;

        // Special Cases
        // p1, q1 and p2 are colinear and p2 lies on segment p1q1
        if (o1 == 0 && IsPointOnLine(p1, p2, q1)) return true;

        // p1, q1 and q2 are colinear and q2 lies on segment p1q1
        if (o2 == 0 && IsPointOnLine(p1, q2, q1)) return true;

        // p2, q2 and p1 are colinear and p1 lies on segment p2q2
        if (o3 == 0 && IsPointOnLine(p2, p1, q2)) return true;

        // p2, q2 and q1 are colinear and q1 lies on segment p2q2
        if (o4 == 0 && IsPointOnLine(p2, q1, q2)) return true;

        return false; // Doesn't fall in any of the above cases
    }

    /// <summary>
    /// Given three colinear points <paramref name="p"/>, <paramref name="q"/> and <paramref name="r"/> determines if
    /// point <paramref name="q"/> is on the linesegment give by <paramref name="p"/> and <paramref name="r"/>.
    /// Returns <see langword="true"/> if <paramref name="q"/> lies on the linesegment.
    /// </summary>
    /// <param name="p">First point of the line segment</param>
    /// <param name="q">Point to check</param>
    /// <param name="r">Second point of the line segment</param>
    /// <returns>
    /// Returns <see langword="true"/> if <paramref name="q"/> lies on the linesegment given by <paramref name="p"/>
    /// and <paramref name="r"/>
    /// </returns>
    public static bool IsPointOnLine(Vector2 p, Vector2 q, Vector2 r)
    {
        return q.X <= Mathf.Max(p.X, r.X) && q.X >= Mathf.Min(p.X, r.X)
            && q.Y <= Mathf.Max(p.Y, r.Y) && q.Y >= Mathf.Min(p.Y, r.Y);
    }

    /// <summary>
    /// Given an ordered triplet of points <paramref name="p"/>, <paramref name="q"/> and <paramref name="r"/>
    /// determines the orientation. Returns 0 if the points are colinear, 1 if their orientation is clockwise and 2
    /// if their orientation is counterclockwise.
    /// </summary>
    /// <param name="p">First point of the triplet</param>
    /// <param name="q">Second point of the triplet</param>
    /// <param name="r">Thrid point of the triplet</param>
    /// <returns>
    /// Returns 0 if the points are colinear, 1 if their orientation is clockwise and 2 if their orientation is
    /// counterclockwise
    /// </returns>
    private static int Orientation(Vector2 p, Vector2 q, Vector2 r)
    {
        // See https://www.geeksforgeeks.org/orientation-3-ordered-points/
        // for details of below formula.
        float val = ((q.Y - p.Y) * (r.X - q.X))
                  - ((q.X - p.X) * (r.Y - q.Y));

        if (Mathf.Abs(val) <= EPS) return 0;  // colinear

        return (val > 0.0) ? 1 : 2; // clock or counterclock wise
    }

    /// <summary>
    /// Determines if two polygons intersect. Returns <see langword="true"/> if any part of the polygons intersect or
    /// one contains the other.
    /// </summary>
    /// <param name="polygon1">First polygon</param>
    /// <param name="polygon2">Second polygon</param>
    /// <returns>
    /// Returns <see langword="true"/> if any part of the polygons intersect or one contains the other
    /// </returns>
    public static bool PolygonsIntersect(List<Vector2> polygon1, List<Vector2> polygon2)
    {
        for (int i = 0; i < polygon1.Count; i++)
        {
            for (int j = 0; j < polygon2.Count; j++)
            {
                if (LinesIntersect(polygon1[i], polygon1[(i + 1) % polygon1.Count], polygon2[j], polygon2[(j + 1) % polygon2.Count]))
                {
                    return true;
                }
            }
        }

        return IsPointInPolygon(polygon2[0], polygon1)
            || IsPointInPolygon(polygon1[0], polygon2);
    }

    /// <summary>
    /// Determines if <paramref name="small"/> is fully contained by <paramref name="big"/>.
    /// </summary>
    /// <param name="small">The small polygon</param>
    /// <param name="big">The big polygon</param>
    /// <returns>Returns <see langword="true"/> if <paramref name="big"/> fully contains <paramref name="small"/></returns>
    public static bool IsPolygonInPolygon(List<Vector2> small, List<Vector2> big)
    {
        if (small.Count == 0)
        {
            return true;
        }
        foreach (var point in small)
        {
            if (!IsPointInPolygon(point, big))
            {
                return false;
            }
        }
        return true;
    }

    // /// <summary>
    // /// Transforms <paramref name="line"/> by first rotating its points around <paramref name="rotationOrigin"/> by <paramref
    // /// name="angle"/> radians and then applying <paramref name="translation"/>.
    // /// </summary>
    // /// <param name="line">Line to rotate</param>
    // /// <param name="rotationOrigin">Origin of rotation</param>
    // /// <param name="angle">Angle of rotation in radians</param>
    // /// <param name="translation">Translation</param>
    // public static void TransformLine(List<Vector2> line, Vector2 rotationOrigin, float angle, Vector2 translation)
    // {
    //     foreach (var point in line)
    //     {
    //         point.RotateAroundPoint(rotationOrigin, angle);
    //         point.Add(translation);
    //     }
    // }

    // /// <summary>
    // /// Transforms <paramref name="polygon"/> by first rotating its points around <paramref name="rotationOrigin"/> by <paramref
    // /// name="angle"/> radians and then applying <paramref name="translation"/>.
    // /// </summary>
    // /// <param name="polygon">Polygon to rotate</param>
    // /// <param name="rotationOrigin">Origin of rotation</param>
    // /// <param name="angle">Angle of rotation in radians</param>
    // /// <param name="translation">Translation</param>
    // public static void TransformPolygon(List<Vector2> polygon, Vector2 rotationOrigin, float angle, Vector2 translation)
    // {
    //     foreach (var point in polygon)
    //     {
    //         point.RotateAroundPoint(rotationOrigin, angle);
    //         point.Add(translation);
    //     }
    // }

    // /// <summary>
    // /// Transforms <paramref name="point"/> by rotating it around <paramref name="PositionPoint"/> by <paramref
    // /// name="angle"/> radians.
    // /// </summary>
    // /// <param name="point">Point to rotate</param>
    // /// <param name="PositionPoint">Origin of rotation</param>
    // /// <param name="angle">Angle of rotation in radians</param>
    // public static Vector2 RotatePoint(Vector2 point, Vector2 PositionPoint, float angle)
    // {
    //     var angleInRadians = angle * (Mathf.PI / 180);
    //     var cosTheta = Mathf.Cos(angle);
    //     var sinTheta = Mathf.Sin(angle);
    //     return new Vector2
    //     {
    //         x =
    //             ((cosTheta * (point.X - PositionPoint.X))
    //              - (sinTheta * (point.Y - PositionPoint.Y)) + PositionPoint.X),
    //         y =
    //             ((sinTheta * (point.X - PositionPoint.X))
    //              + (cosTheta * (point.Y - PositionPoint.Y)) + PositionPoint.Y)
    //     };
    // }

    /// <summary>
    /// Calculates the dot product between <paramref name="vec1"/> and <paramref name="vec2"/>
    /// </summary>
    /// <param name="vec1">First Vector</param>
    /// <param name="vec2">Second Vector</param>
    public static float DotProduct(Vector2 vec1, Vector2 vec2)
    {
        return vec1.X * vec2.X + vec1.Y * vec2.Y;
    }

    /// <summary>
    /// Calculates the angle between <paramref name="vec1"/> and <paramref name="vec2"/>. The result is
    /// between -PI and PI
    /// </summary>
    /// <param name="vec1">First Vector</param>
    /// <param name="vec2">Second Vector</param>
    public static float AngleBetweenVectors(Vector2 vec1, Vector2 vec2)
    {
        var crossProduct2D = vec1.X * vec2.Y - vec1.Y * vec2.X;

        return Mathf.Atan2(crossProduct2D, DotProduct(vec1, vec2));
    }

    // /// <summary>
    // ///   Creates a polygon pointlist by extending a line to the left and the right side.
    // /// </summary>
    // public static List<Vector2> CreateWidePolygonFromLine(List<Vector2> points, float thickness, bool drawRoundedCorners = true)
    // {
    //     float halfWidth = 0.5 * thickness;

    //     // The enclosing border points starting at the first point for the left and right side (vital for ZFighting)
    //     List<Vector2> leftBorderPoints = new();
    //     List<Vector2> rightBorderPoints = new();

    //     // ITERATE POINTS
    //     for (int index = 0; index < points.Count - 1; index++)
    //     {
    //         Vector2 previousPoint = points[index];
    //         Vector2 nextPoint = points[index + 1];
    //         Vector2? nextNextPoint = points.ElementAtOrDefault(index + 2);

    //         Vector2 currentToNextPoint = nextPoint - previousPoint;
    //         float orientation = currentToNextPoint.Orientation.NormalizeAngle();

    //         float nextOrientation = ((nextNextPoint != null) ? ((float)(nextNextPoint - nextPoint).Orientation) : 0).NormalizeAngle();
    //         bool isLeftCurve = (nextOrientation - orientation).NormalizeAngle() is > 0 and < Mathf.PI;

    //         float left = orientation + 0.5 * Mathf.PI;
    //         float right = orientation - 0.5 * Mathf.PI;
    //         float currentLeftOrRight = isLeftCurve ? left : right;

    //         // Start
    //         if (index == 0)
    //         {
    //             leftBorderPoints.Add(previousPoint.MoveInDirection(halfWidth, left));
    //             rightBorderPoints.Add(previousPoint.MoveInDirection(-halfWidth, left));
    //         }

    //         if (nextNextPoint != null)
    //         {
    //             // Inbetween
    //             float nextLeft = nextOrientation + 0.5 * Mathf.PI;
    //             float nextRight = nextOrientation - 0.5 * Mathf.PI;
    //             float nextLeftOrRight = isLeftCurve ? nextLeft : nextRight;

    //             // Find inner intersection: Shift the previous and next point laterally to the the inner of the curve and 
    //             Vector2 currentPointInwards = previousPoint.MoveInDirection(halfWidth, currentLeftOrRight);
    //             Vector2 nextPointInwards = nextPoint.MoveInDirection(halfWidth, nextLeftOrRight);
    //             Vector2? innerIntersection = GeometryUtilities.LineSegmentIntersectionDirection(
    //                 currentPointInwards, orientation,
    //                 nextPointInwards, nextOrientation);

    //             // Inner intersection is always added as polygon point as there is no option of rounding or not
    //             (isLeftCurve ? leftBorderPoints : rightBorderPoints).Add(innerIntersection!);

    //             if (drawRoundedCorners)
    //             {
    //                 const float Tau = 2 * Mathf.PI;

    //                 float startTemp = isLeftCurve ? (orientation - 0.25 * Tau).NormalizeAngle() : (orientation + 0.25 * Tau).NormalizeAngle();
    //                 float orientationDelta = (nextOrientation - orientation).NormalizeAngle(); // Positive = leftcurve
    //                 float endTemp = (startTemp + orientationDelta).NormalizeAngle();


    //                 float end = isLeftCurve ? endTemp : startTemp;
    //                 float start = isLeftCurve ? startTemp : endTemp;

    //                 // end must be > start
    //                 if (start > end)
    //                 {
    //                     end += Tau;
    //                 }
    //                 Debug.Assert(end > start);

    //                 float delta = end - start;
    //                 float pointCountPerArc = (int)(delta * 20 / Tau); // 20 corners per full circle
    //                 float increment = delta / pointCountPerArc;

    //                 List<Vector2> circlePolygon = CreateCirclePolygon(start, end, increment, nextPoint, halfWidth);

    //                 if (!isLeftCurve)
    //                 {
    //                     circlePolygon.Reverse();
    //                 }
    //                 (isLeftCurve ? rightBorderPoints : leftBorderPoints).AddRange(circlePolygon);
    //             }
    //             else
    //             {
    //                 // Find outer intersection: Shift the previous and next point laterally to the the outer of the curve and 
    //                 Vector2 currentPointOutwards = previousPoint.MoveInDirection(-halfWidth, currentLeftOrRight);
    //                 Vector2 nextPointOutwards = nextPoint.MoveInDirection(-halfWidth, nextLeftOrRight);
    //                 Vector2? outerIntersection = GeometryUtilities.LineSegmentIntersectionDirection(
    //                     currentPointOutwards, orientation,
    //                     nextPointOutwards, nextOrientation);

    //                 (isLeftCurve ? rightBorderPoints : leftBorderPoints).Add(outerIntersection!);
    //             }
    //         }
    //         else
    //         {
    //             // End
    //             leftBorderPoints.Add(nextPoint.MoveInDirection(halfWidth, left));
    //             rightBorderPoints.Add(nextPoint.MoveInDirection(-halfWidth, left));
    //         }
    //     }

    //     leftBorderPoints.Reverse();

    //     // Create widened polygon by merging right with left border points
    //     List<Vector2> polygon = rightBorderPoints.Concat(leftBorderPoints).ToList();

    //     return polygon;
    // }

    private static List<Vector2> CreateCirclePolygon(float startAngle, float endAngle, float angleIncrement, Vector2 offset, float halfWidth)
    {
        List<Vector2> polygon = new();

        for (float angle = startAngle; angle <= endAngle + 0.001; angle += angleIncrement)
        {
            polygon.Add(new Vector2(
                offset.X + halfWidth * Mathf.Cos(angle),
                offset.Y + halfWidth * Mathf.Sin(angle)));
        }
        return polygon;
    }

    private static float NormalizeAngle(this float angle)
    {
        if (angle.IsNan())
        {
            return 0;
        }

        float normalized = angle % (2 * Mathf.Pi);

        if (normalized < 0)
        {
            normalized += 2 * Mathf.Pi;
        }

        Debug.Assert(normalized >= 0);

        return normalized;
    }
    // Following part is to detect a polygon collision.
    // Adjusted source by: https://www.codeproject.com/Articles/15573/2D-Polygon-Collision-Detection

    /// <summary>
    /// Calculate the projection of a polygon on an axis and returns it as a [min, max] interval
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="polygon"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    private static void ProjectPolygon(Vector2 axis, List<Vector2> polygon, ref float min, ref float max)
    {
        // To project a point on an axis use the dot product
        float d = axis.DotProduct(polygon[0]);
        min = d;
        max = d;
        for (int i = 0; i < polygon.Count; i++)
        {
            d = polygon[i].DotProduct(axis);
            if (d < min)
            {
                min = d;
            }
            else
            {
                if (d > max)
                {
                    max = d;
                }
            }
        }
    }

    /// <summary>
    /// Calculate the distance between [minA, maxA] and [minB, maxB].
    /// The distance will be negative if the intervals overlap.
    /// </summary>
    /// <param name="minA"></param>
    /// <param name="maxA"></param>
    /// <param name="minB"></param>
    /// <param name="maxB"></param>
    /// <returns></returns>
    public static float IntervalDistance(float minA, float maxA, float minB, float maxB)
    {
        if (minA < minB)
        {
            return minB - maxA;
        }
        else
        {
            return minA - maxB;
        }
    }

    /// <summary>
    /// Check if polygon A is going to collide with polygon B.
    /// </summary>
    /// <param name="polygonA"></param>
    /// <param name="polygonB"></param>
    /// <returns></returns>
    public static bool PolygonCollision(List<Vector2> polygonA, List<Vector2> polygonB)
    {
        List<Vector2> edgesPolyA = BuildEdges(polygonA).ToList();
        List<Vector2> edgesPolyB = BuildEdges(polygonB).ToList();
        int edgeCountA = edgesPolyA.Count;
        int edgeCountB = edgesPolyB.Count;
        Vector2 edge;

        // Loop through all the edges of both polygons
        for (int edgeIndex = 0; edgeIndex < edgeCountA + edgeCountB; edgeIndex++)
        {
            if (edgeIndex < edgeCountA)
            {
                edge = edgesPolyA[edgeIndex];
            }
            else
            {
                edge = edgesPolyB[edgeIndex - edgeCountA];
            }

            // Find the axis perpendicular to the current edge
            Vector2 axis = new(-edge.X, edge.Y);
            axis = axis.Normalized();

            // Find the projection of the polygon on the current axis
            float minA = 0; float minB = 0; float maxA = 0; float maxB = 0;
            ProjectPolygon(axis, polygonA, ref minA, ref maxA);
            ProjectPolygon(axis, polygonB, ref minB, ref maxB);

            // Check if the polygon projections are currently intersecting
            if (IntervalDistance(minA, maxA, minB, maxB) > 0) return false;
        }

        return true;
    }

    /// <summary>
    /// Builds a list of <see cref="Vector2"/> with the edges from a given polygon <paramref name="points"/>.
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    public static IEnumerable<Vector2> BuildEdges(List<Vector2> points)
    {
        Vector2 p1;
        Vector2 p2;
        for (int i = 0; i < points.Count; i++)
        {
            p1 = points[i];
            if (i + 1 >= points.Count)
            {
                p2 = points[0];
            }
            else
            {
                p2 = points[i + 1];
            }
            yield return p2 - p1;
        }
    }
}
