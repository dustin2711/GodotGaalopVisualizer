using Godot;
using System.Collections.Generic;
using System.Linq;


public class LineBuilder
{
	/// <summary>
	///   For drawing the rounded corners.
	/// </summary>
	private const int CircleResolution = 20;

	/// <summary>
	///   One circle rotation.
	/// </summary>
	public const float Tau = 2 * Mathf.Pi;

	protected readonly float halfWidth = 50;

	// Nicht adden sondern assignen
	// The enclosing border points starting at the first point for the left and right side (vital for ZFighting)
	protected readonly List<Vector2> leftPoints = new();

	private bool drawPoints;
	protected List<Vector2> points;

	protected readonly List<Vector2> rightPoints = new();

	Node2D parent;

	public LineBuilder(Node2D parent, List<Vector2> points, float width = 100, bool drawPoints = false)
	{
		this.parent = parent;
		this.points = points;
		this.drawPoints = drawPoints;
		halfWidth = 0.5f * width;

		if (drawPoints)
		{
			foreach ((int index, Vector2 point) in this.points.Enumerate())
			{
				DrawPoint(point, index.ToString(), new Color("Black"));
			}
		}
	}
 
	public void DrawText(Vector2 position, string text)
	{
		SystemFont font = new();
		font.FontNames = new string[] { "Arial" };
		// parent.DrawString(font, position, text);

		Label label = new();
		label.Text = text;
		label.Position = position;
		parent.AddChild(label);
	}

	private void DrawPoint(Vector2 position, string text = "", Color? color = null)
	{
		const float radius = 6;

		Polygon2D poly = new();
		poly.Polygon = new Vector2[]
		{
			new(0, radius),
			new(radius, 0),
			new(0, -radius),
			new(-radius, 0),
		};
		poly.Offset = position;
		poly.Color = color ?? new Color("Black");
		parent.AddChild(poly);

		DrawText(position, text);
	}

	public Vector2[] CreatePoints()
	{
		// Bring CPU on heat
		leftPoints.Clear();
		rightPoints.Clear();
		for (int index = 0; index < points.Count - 1; index++)
		{
			HandlePointOfIndex(index, true);
		}
		leftPoints.Clear();
		rightPoints.Clear();
		for (int index = 0; index < points.Count - 1; index++)
		{
			HandlePointOfIndex(index, false);
		}

		// Old approach
		leftPoints.Clear();
		rightPoints.Clear();
		Watch.Start();
		for (int index = 0; index < points.Count - 1; index++)
		{
			HandlePointOfIndex(index, false);
		}
		// Watch.Log("Old approach");

		// New approach
		leftPoints.Clear();
		rightPoints.Clear();
		Watch.Start();
		for (int index = 0; index < points.Count - 1; index++)
		{
			HandlePointOfIndex(index, true);
		}
		// Watch.Log("New approach");


		// foreach ((int index, Vector2 leftPoint) in leftPoints.Enumerate())
		// {
		//     DrawPoint(leftPoint, index.ToString(), new Color("Red"));
		// }

		// foreach ((int index, Vector2 rightPoint) in rightPoints.Enumerate())
		// {
		//     DrawPoint(rightPoint, index.ToString(), new Color("Blue"));
		// }

		// ToDo: Reverse beim assignen
		leftPoints.Reverse();
		Vector2[] allPoints = rightPoints.Concat(leftPoints).ToArray();

		// GD.Print(allPoints.JoinString());
		return allPoints;

		// DrawDebugBorderPoints();
	}

	private void HandlePointOfIndex(int index, bool useGeometricAlgebra)
	{
		Vector2 previousPoint = points[index];
		Vector2 nextPoint = points[index + 1];
		Vector2? nextNextPoint = (index + 2) < points.Count
			? points[index + 2]
			: null;

		Vector2 currentToNextPoint = nextPoint - previousPoint;
		float orientation = currentToNextPoint.Orientation().NormalizeAngle();

		float nextOrientation = (nextNextPoint.HasValue
			? (nextNextPoint.Value - nextPoint).Orientation()
			: 0).NormalizeAngle();
		bool isLeftCurve = (nextOrientation - orientation).NormalizeAngle() is > 0 and < Mathf.Pi;

		float left = orientation + 0.5f * Mathf.Pi;
		float right = orientation - 0.5f * Mathf.Pi;
		float currentLeftOrRight = isLeftCurve ? left : right;

		// Start
		if (index == 0)
		{
			leftPoints.Add(previousPoint.ToVector2MovedInDirection(halfWidth, left));
			rightPoints.Add(previousPoint.ToVector2MovedInDirection(-halfWidth, left));
		}

		if (nextNextPoint.HasValue)
		{
			if (useGeometricAlgebra)
			{
				(Vector2 leftPoint, Vector2 rightPoint) = GetLeftAndRightIntersection2Shortened(
					previousPoint.X, previousPoint.Y, nextPoint.X, nextPoint.Y, nextNextPoint.Value.X, nextNextPoint.Value.Y, halfWidth);

				if (isLeftCurve)
				{
					rightPoints.Add(leftPoint);
					leftPoints.Add(rightPoint);
				}
				else
				{
					leftPoints.Add(leftPoint);
					rightPoints.Add(rightPoint);
				}

				//Helper.LogAndRestartStopwatch("Geometric Algebra");
			}
			else
			{
				float nextLeft = nextOrientation + 0.5f * Mathf.Pi;
				float nextRight = nextOrientation - 0.5f * Mathf.Pi;
				float nextLeftOrRight = isLeftCurve ? nextLeft : nextRight;

				Vector2 innerIntersection = FindInnerIntersection(orientation, nextOrientation,
				previousPoint, nextPoint, currentLeftOrRight, nextLeftOrRight);

				// DrawPoint(innerIntersection);
				// Inner intersection is always added as polygon point as there is no option of rounding or not
				if (isLeftCurve)
				{
					leftPoints.Add(innerIntersection);
				} 
				else
				{
					rightPoints.Add(innerIntersection);
				}

				// Draw spiky
				// Find outer intersection: Shift the previous and next point laterally to the the outer of the curve
				Vector2 currentPointOutwards = previousPoint.MoveInDirection(-halfWidth, currentLeftOrRight);
				Vector2 nextPointOutwards = nextPoint.MoveInDirection(-halfWidth, nextLeftOrRight);
				if (GeometryUtilities.LineSegmentIntersectionDirection(
					currentPointOutwards, orientation,
					nextPointOutwards, nextOrientation) is Vector2 outerIntersection)
				{
					if (isLeftCurve)
					{
						rightPoints.Add(outerIntersection);
					}
					else
					{
						leftPoints.Add(outerIntersection);
					}
				}
			}
		}
		else
		{
			// End
			leftPoints.Add(nextPoint.ToVector2MovedInDirection(halfWidth, left));
			rightPoints.Add(nextPoint.ToVector2MovedInDirection(-halfWidth, left));
		}
	}

	/// <summary>
	///   Improved version of gaalop script: https://gaalopweb.esa.informatik.tu-darmstadt.de/gaalopweb/res/cpp/input?id=db822e7f2a827d99e37198e713ebab6b8c72a213e834fd6e1127d7c
	/// </summary>
	(Vector2 leftPoint, Vector2 rightPoint) GetLeftAndRightIntersection(float ax, float ay, float bx, float by, float cx, float cy, float dist)
	{
		float lineAB_1 = ax * by + (-(ay * bx)); // e0
		float lineAB_2 = -(by + (-ay)); // e1
		float lineAB_3 = (--bx) + -ax; // e2

		float product = lineAB_2 * lineAB_2 + lineAB_3 * lineAB_3;
		float absolute = sqrtf(product) / product;

		float lineAB1 = lineAB_1 * absolute; // e0
		float lineAB2 = lineAB_2 * absolute; // e1
		float lineAB3 = lineAB_3 * absolute; // e2

		float lineABL1 = lineAB1 - dist; // e0
		float lineABR1 = lineAB1 + dist; // e0


		float lineBC_1 = bx * cy + (-(by * cx)); // e0
		float lineBC_2 = -(cy + (-by)); // e1
		float lineBC_3 = cx + -bx; // e2

		float product2 = lineBC_2 * lineBC_2 + lineBC_3 * lineBC_3;
		float absolute2 = sqrtf(product2) / product2;
		float lineBC1 = lineBC_1 * absolute2; // e0
		float lineBC2 = lineBC_2 * absolute2; // e1
		float lineBC3 = lineBC_3 * absolute2; // e2
		float lineBCL1 = lineBC1 - dist; // e0
		float lineBCR1 = lineBC1 + dist; // e0


		float bL4 = lineABL1 * lineBC2 + (-(lineAB2 * lineBCL1)); // e0 ^ e1
		float bL5 = lineABL1 * lineBC3 + (-(lineAB3 * lineBCL1)); // e0 ^ e2
		float bL6 = lineAB2 * lineBC3 + (-(lineAB3 * lineBC2)); // e1 ^ e2

		float bR4 = lineABR1 * lineBC2 + (-(lineAB2 * lineBCR1)); // e0 ^ e1
		float bR5 = lineABR1 * lineBC3 + (-(lineAB3 * lineBCR1)); // e0 ^ e2
		float bR6 = lineAB2 * lineBC3 + (-(lineAB3 * lineBC2)); // e1 ^ e2

		return (ToVector2(bL4, bL5, bL6), ToVector2(bR4, bR5, bR6));
	}

/// <summary>
///   Unimproved Gaalop script
/// </summary>
(Vector2 leftPoint, Vector2 rightPoint) GetLeftAndRightIntersection2(float ax, float ay, float bx, float by, float cx, float cy, float dist)
{
	float[] bL = new float[8];
	float[] bR = new float[8];

	float[] a = new float[8];
	float[] b = new float[8];
	float[] c = new float[8];
	float[] lineAB = new float[8];
	float[] lineAB_ = new float[8];
	float[] lineABL = new float[8];
	float[] lineABR = new float[8];
	float[] lineBC = new float[8];
	float[] lineBC_ = new float[8];
	float[] lineBCL = new float[8];
	float[] lineBCR = new float[8];
	float temp_gcse_1, temp_gcse_10, temp_gcse_11, temp_gcse_12, temp_gcse_13, temp_gcse_14, temp_gcse_15, temp_gcse_16, temp_gcse_17, temp_gcse_18, temp_gcse_19, temp_gcse_2, temp_gcse_20, temp_gcse_21, temp_gcse_23, temp_gcse_3, temp_gcse_4, temp_gcse_5, temp_gcse_6, temp_gcse_7, temp_gcse_8, temp_gcse_9;
	a[5] = (-ax); // e0 ^ e2
	b[5] = (-bx); // e0 ^ e2
	c[5] = (-cx); // e0 ^ e2
	temp_gcse_6 = (-b[5]);
	lineAB_[1] = (-a[5]) * by + (-(ay * temp_gcse_6)); // e0
	lineAB_[2] = (-(by + (-ay))); // e1
	lineAB_[3] = temp_gcse_6 + a[5]; // e2
	temp_gcse_2 = lineAB_[2] * lineAB_[2] + lineAB_[3] * lineAB_[3];
	temp_gcse_4 = temp_gcse_2 * temp_gcse_2;
	temp_gcse_5 = fabs(temp_gcse_2);
	temp_gcse_9 = sqrtf(temp_gcse_5);
	temp_gcse_12 = lineAB_[2] * lineAB_[2];
	temp_gcse_15 = sqrtf(fabs(temp_gcse_4));
	temp_gcse_16 = lineAB_[3] * lineAB_[3];
	temp_gcse_20 = temp_gcse_9 / temp_gcse_15;
	temp_gcse_23 = fabs(temp_gcse_4);
	lineAB[1] = lineAB_[1] * temp_gcse_20; // e0
	lineAB[2] = lineAB_[2] * temp_gcse_20; // e1
	lineAB[3] = lineAB_[3] * temp_gcse_20; // e2
	lineABL[1] = lineAB[1] - dist; // e0
	lineABR[1] = lineAB[1] + dist; // e0
	temp_gcse_11 = (-c[5]);
	lineBC_[1] = temp_gcse_6 * cy + (-(by * temp_gcse_11)); // e0
	lineBC_[2] = (-(cy + (-by))); // e1
	lineBC_[3] = temp_gcse_11 + b[5]; // e2
	temp_gcse_1 = sqrtf(fabs((lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]) * (lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3])));
	temp_gcse_7 = fabs(lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]);
	temp_gcse_10 = sqrtf(temp_gcse_7);
	temp_gcse_13 = fabs((lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]) * (lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]));
	temp_gcse_14 = lineBC_[2] * lineBC_[2];
	temp_gcse_17 = lineBC_[3] * lineBC_[3];
	temp_gcse_18 = temp_gcse_10 / temp_gcse_1;
	temp_gcse_19 = (lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]) * (lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]);
	temp_gcse_21 = lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3];
	lineBC[1] = lineBC_[1] * temp_gcse_18; // e0
	lineBC[2] = lineBC_[2] * temp_gcse_18; // e1
	lineBC[3] = lineBC_[3] * temp_gcse_18; // e2
	lineBCL[1] = lineBC[1] - dist; // e0
	lineBCR[1] = lineBC[1] + dist; // e0
	bL[4] = lineABL[1] * lineBC[2] + (-(lineAB[2] * lineBCL[1])); // e0 ^ e1
	bL[5] = lineABL[1] * lineBC[3] + (-(lineAB[3] * lineBCL[1])); // e0 ^ e2
	temp_gcse_3 = lineAB[3] * lineBC[2];
	temp_gcse_8 = (-temp_gcse_3);
	bL[6] = lineAB[2] * lineBC[3] + temp_gcse_8; // e1 ^ e2
	bR[4] = lineABR[1] * lineBC[2] + (-(lineAB[2] * lineBCR[1])); // e0 ^ e1
	bR[5] = lineABR[1] * lineBC[3] + (-(lineAB[3] * lineBCR[1])); // e0 ^ e2
	bR[6] = bL[6]; // e1 ^ e2

	return (ToVector2(bL), ToVector2(bR));
}

(Vector2 leftPoint, Vector2 rightPoint) GetLeftAndRightIntersection2Shortened(float ax, float ay, float bx, float by, float cx, float cy, float dist)
{
	float[] bL = new float[8];
	float[] bR = new float[8];

	float[] c = new float[8];
	float[] lineAB = new float[8];
	float[] lineAB_ = new float[8];
	float[] lineABL = new float[8];
	float[] lineABR = new float[8];
	float[] lineBC = new float[8];
	float[] lineBC_ = new float[8];
	float[] lineBCL = new float[8];
	float[] lineBCR = new float[8];
	float temp_gcse_1, temp_gcse_10, temp_gcse_11, temp_gcse_15, temp_gcse_18, temp_gcse_2, temp_gcse_20, temp_gcse_3, temp_gcse_4, temp_gcse_5, temp_gcse_6, temp_gcse_7, temp_gcse_9;
	float a5 = (-ax); // e0 ^ e2
	float b5 = (-bx); // e0 ^ e2
	float c5 = (-cx); // e0 ^ e2
	temp_gcse_6 = (-b5);
	lineAB_[1] = (-a5) * by + (-(ay * temp_gcse_6)); // e0
	lineAB_[2] = (-(by + (-ay))); // e1
	lineAB_[3] = temp_gcse_6 + a5; // e2
	temp_gcse_2 = lineAB_[2] * lineAB_[2] + lineAB_[3] * lineAB_[3];
	temp_gcse_4 = temp_gcse_2 * temp_gcse_2;
	temp_gcse_5 = fabs(temp_gcse_2);
	temp_gcse_9 = sqrtf(temp_gcse_5);
	temp_gcse_15 = sqrtf(fabs(temp_gcse_4));
	temp_gcse_20 = temp_gcse_9 / temp_gcse_15;
	lineAB[1] = lineAB_[1] * temp_gcse_20; // e0
	lineAB[2] = lineAB_[2] * temp_gcse_20; // e1
	lineAB[3] = lineAB_[3] * temp_gcse_20; // e2
	lineABL[1] = lineAB[1] - dist; // e0
	lineABR[1] = lineAB[1] + dist; // e0
	temp_gcse_11 = (-c5);
	lineBC_[1] = temp_gcse_6 * cy + (-(by * temp_gcse_11)); // e0
	lineBC_[2] = (-(cy + (-by))); // e1
	lineBC_[3] = temp_gcse_11 + b5; // e2
	temp_gcse_1 = sqrtf(fabs((lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]) * (lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3])));
	temp_gcse_7 = fabs(lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]);
	temp_gcse_10 = sqrtf(temp_gcse_7);
	temp_gcse_18 = temp_gcse_10 / temp_gcse_1;
	lineBC[1] = lineBC_[1] * temp_gcse_18; // e0
	lineBC[2] = lineBC_[2] * temp_gcse_18; // e1
	lineBC[3] = lineBC_[3] * temp_gcse_18; // e2
	lineBCL[1] = lineBC[1] - dist; // e0
	lineBCR[1] = lineBC[1] + dist; // e0
	bL[4] = lineABL[1] * lineBC[2] + (-(lineAB[2] * lineBCL[1])); // e0 ^ e1
	bL[5] = lineABL[1] * lineBC[3] + (-(lineAB[3] * lineBCL[1])); // e0 ^ e2
	temp_gcse_3 = lineAB[3] * lineBC[2];
	bL[6] = lineAB[2] * lineBC[3] + -temp_gcse_3; // e1 ^ e2
	bR[4] = lineABR[1] * lineBC[2] + (-(lineAB[2] * lineBCR[1])); // e0 ^ e1
	bR[5] = lineABR[1] * lineBC[3] + (-(lineAB[3] * lineBCR[1])); // e0 ^ e2
	bR[6] = bL[6]; // e1 ^ e2

	return (ToVector2(bL), ToVector2(bR));
}

	static Vector2 ToVector2(float val4, float val5, float val6)
	{
		return new Vector2(-val5 / val6, val4 / val6);
	}

	static Vector2 ToVector2(float[] array)
	{
		return new Vector2(-array[5] / array[6], array[4] / array[6]);
	}

	float sqrtf(float value) => Mathf.Sqrt(value);
	float fabs(float value) => Mathf.Abs(value);


	/// <summary>
	///   Creates a list of points forming an arc.
	///   EndAngle must be greater than startAngle.
	///   Points will go counter-clockwise. (startAngle 0 means starting right)
	/// </summary>
	public static List<Vector2> CreateArcPolygon(float startAngle, float endAngle,
		Vector2 center, float radius)
	{
		float deltaAngle = endAngle - startAngle;
		int count = (int)(deltaAngle * CircleResolution / Tau); // 20 corners per full circle
		float increment = deltaAngle / count;

		List<Vector2> points = new();

		for (float angle = startAngle; angle <= endAngle + 0.001; angle += increment)
		{
			points.Add(new Vector2(
				center.X + radius * Mathf.Cos(angle),
				center.Y + radius * Mathf.Sin(angle)));
		}
		return points;
	}

	/// <summary>
	///   Returns a list describing a triangles facing towards "forward". Returns [leftPoint, tipperPoint, rightPoint].
	/// </summary>
	public static Vector2[] CreateArrowPoints(Vector2 startPoint, float forward, bool swapLeftAndRight, float radius)
	{
		float sign = swapLeftAndRight ? -1 : 1;
		float left = forward + sign * 0.25f * Tau;
		float right = forward - sign * 0.25f * Tau;

		Vector2 leftPoint = startPoint.MoveInDirection(radius, left);
		Vector2 tipperPoint = startPoint.MoveInDirection(-radius, forward);
		Vector2 rightPoint = startPoint.MoveInDirection(radius, right);

		return new Vector2[]
		{
			leftPoint,
			tipperPoint,
			rightPoint
		};
	}

	public static List<Vector2> CreateCircle(Vector2 startPoint, float forward, float radius)
	{
		// The angle of the intersection of line and circle
		float angleOffset = Mathf.Atan2(0.5f, 0.75f.Root(2));

		List<Vector2> points = CreateArcPolygon(forward + angleOffset, forward - angleOffset + Tau,
			startPoint, radius);

		return points;
	}

	public static List<Vector2> CreateCircle(Vector2 startPoint, float radius)
	{
		return CreateArcPolygon(0, Tau, startPoint, radius);
	}

	/// <summary>
	///   Returns [frontLeft, rearLeft, rearRight, frontRight]
	/// </summary>
	public static Vector2[] CreateRectangle(Vector2 center, float forward, float radius)
	{
		float left = forward + 0.25f * Tau;
		float right = forward - 0.25f * Tau;

		Vector2 front = center.MoveInDirection(radius, forward);
		Vector2 frontLeft = front.MoveInDirection(radius, left);
		Vector2 frontRight = front.MoveInDirection(radius, right);
		Vector2 rearLeft = frontLeft.MoveInDirection(-2 * radius, forward);
		Vector2 rearRight = frontRight.MoveInDirection(-2 * radius, forward);

		return new Vector2[]
		{
			frontLeft,
			rearLeft,
			rearRight,
			frontRight
		};
	}

	public void DrawDebugBorderPoints()
	{
		// Spawn points for each polygon border point
		foreach (Vector2 left in leftPoints)
		{
			// core.SpawnPoint(left.ToMBVector(), MBColor.Red, 0.1);
		}
		foreach (Vector2 right in rightPoints)
		{
			// core.SpawnPoint(right.ToMBVector(), MBColor.Blue, 0.1);
		}
	}

	/// <summary>
	///  Find inner intersection: Shift the previous and next point laterally
	///  to the inner of the curve to find the intersection.
	/// </summary>
	public Vector2 FindInnerIntersection(float orientation, float nextOrientation,
		Vector2 previousPoint, Vector2 nextPoint,
		float currentLeftOrRight, float nextLeftOrRight)
	{
		Vector2 currentPointInwards = previousPoint.MoveInDirection(
			halfWidth, currentLeftOrRight);
		Vector2 nextPointInwards = nextPoint.MoveInDirection(
			halfWidth, nextLeftOrRight);
		Vector2? innerIntersection = GeometryUtilities.LineSegmentIntersectionDirection(
			currentPointInwards, orientation,
			nextPointInwards, nextOrientation)!;

		// If no intersection is found, use the mean value
		innerIntersection ??= 0.5f * (currentPointInwards + nextPointInwards);

		return innerIntersection.Value;
	}
}
