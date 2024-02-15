using Godot;
using System.Collections.Generic;
using System.Linq;


public class LineBuilder2
{
	/// <summary>
	///   One circle rotation.
	/// </summary>
	public const float Tau = 2 * Mathf.Pi;
	public const float Quarter = 0.25f * Tau;

	public static Vector2[] Create(Vector2[] points, float halfWidth, bool useGaalop)
	{
		List<Vector2> leftPoints = new();
		List<Vector2> rightPoints = new();

		// Iterate points
		for (int index = 0; index < points.Length - 2; index++)
		{
			Vector2 lastPoint = points[index];
			Vector2 point = points[index + 1];
			Vector2 nextPoint = points[index + 2];

			Vector2 lastToCurrent = point - lastPoint;
			float lastOrientation = lastToCurrent.Orientation().NormalizeAngle();

			float nextOrientation = (nextPoint - point).Orientation();
			bool isLeftCurve = (nextOrientation - lastOrientation).NormalizeAngle() is > 0 and < Mathf.Pi;

			if (useGaalop)
			{
				(Vector2 leftPoint, Vector2 rightPoint) = GetLeftAndRightIntersection2Shortened(
					lastPoint.X, lastPoint.Y, point.X, point.Y, nextPoint.X, nextPoint.Y, halfWidth);

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
			}
			else
			{
				float left = lastOrientation + Quarter;
				float right = lastOrientation - Quarter;
				float leftOrRight = isLeftCurve ? left : right;

				float nextLeft = nextOrientation + Quarter;
				float nextRight = nextOrientation - Quarter;
				float nextLeftOrRight = isLeftCurve ? nextLeft : nextRight;

				Vector2 innerIntersection = FindInnerIntersection(lastOrientation, nextOrientation,
					lastPoint, point, leftOrRight, nextLeftOrRight, halfWidth);

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
				Vector2 currentPointOutwards = lastPoint.MoveInDirection(-halfWidth, leftOrRight);
				Vector2 nextPointOutwards = point.MoveInDirection(-halfWidth, nextLeftOrRight);

				if (GeometryUtilities.LineSegmentIntersectionDirection(
					currentPointOutwards, lastOrientation,
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

		// Gaalop right points: Mitte+außen
		// Gaalop left points: Mitte+außen
		// Normal left points: Mitte+außen
		// Normal right points: Nur Mitte (+ werid)

		leftPoints.Reverse();
		Vector2[] polygonPoints = rightPoints.Concat(leftPoints).ToArray();
		// ResultingPoints = rightPoints.ToArray();
		// ResultingPoints = leftPoints.ToArray();
		return polygonPoints;
	}

	private static (Vector2 leftPoint, Vector2 rightPoint) GetLeftAndRightIntersection2Shortened(float ax, float ay, float bx, float by, float cx, float cy, float dist)
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

	static Vector2 ToVector2(float[] array)
	{
		return new Vector2(-array[5] / array[6], array[4] / array[6]);
	}

	static float sqrtf(float value) => Mathf.Sqrt(value);
	static float fabs(float value) => Mathf.Abs(value);

	/// <summary>
	///  Find inner intersection: Shift the previous and next point laterally
	///  to the inner of the curve to find the intersection.
	/// </summary>
	public static Vector2 FindInnerIntersection(float orientation, float nextOrientation,
		Vector2 previousPoint, Vector2 nextPoint,
		float currentLeftOrRight, float nextLeftOrRight, float halfWidth)
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