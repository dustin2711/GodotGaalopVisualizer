using Godot;
using System;
using System.Collections.Generic;
using System.Linq;


public class PolygonFromLineBuilder
{
	/// <summary>
	///   One circle rotation.
	/// </summary>
	public const float Tau = 2 * Mathf.Pi;

	public const float Quarter = 0.25f * Tau;

	public static Vector2[] Default(Vector2[] linePoints, float halfWidth)
	{
		List<Vector2> leftPoints = new();
		List<Vector2> rightPoints = new();

		// Iterate points
		for (int index = 0; index < linePoints.Length - 2; index++)
		{
			Vector2 lastPoint = linePoints[index];
			Vector2 point = linePoints[index + 1];
			Vector2 nextPoint = linePoints[index + 2];

			Vector2 lastToCurrent = point - lastPoint;
			float lastOrientation = lastToCurrent.Orientation().NormalizeAngle();

			float nextOrientation = (nextPoint - point).Orientation();
			bool isLeftCurve = (nextOrientation - lastOrientation).NormalizeAngle() is > 0 and < Mathf.Pi;

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

		leftPoints.Reverse();
		Vector2[] polygonPoints = rightPoints.Concat(leftPoints).ToArray();
		return polygonPoints;
	}

	public static Vector2[] DefaultNew(Vector2[] linePoints, float halfWidth)
	{
		// Number of loops
		int count = linePoints.Count() - 2;

		Vector2[] polygonPoints = new Vector2[2 * count];

		float lastOrientation = 0;

		// Iterate points
		for (int index = 0; index < linePoints.Length - 2; index++)
		{
			Vector2 lastPoint = linePoints[index];
			Vector2 point = linePoints[index + 1];
			Vector2 nextPoint = linePoints[index + 2];

			Vector2 lastToCurrent = point - lastPoint;

			if (index == 0)
			{
				lastOrientation = lastToCurrent.Orientation().NormalizeAngle();
			}

			float nextOrientation = (nextPoint - point).Orientation();
			bool isLeftCurve = (nextOrientation - lastOrientation).NormalizeAngle() is > 0 and < Mathf.Pi;

			float left = lastOrientation + Quarter;
			float right = lastOrientation - Quarter;
			float leftOrRight = isLeftCurve ? left : right;

			float nextLeft = nextOrientation + Quarter;
			float nextRight = nextOrientation - Quarter;
			float nextLeftOrRight = isLeftCurve ? nextLeft : nextRight;

			Vector2 innerIntersection = FindInnerIntersection(lastOrientation, nextOrientation,
				lastPoint, point, leftOrRight, nextLeftOrRight, halfWidth);

			// Draw spiky
			// Find outer intersection: Shift the previous and next point laterally to the the outer of the curve
			Vector2 currentPointOutwards = lastPoint.MoveInDirection(-halfWidth, leftOrRight);
			Vector2 nextPointOutwards = point.MoveInDirection(-halfWidth, nextLeftOrRight);

			Vector2 outerIntersection = GeometryUtilities.LineSegmentIntersectionDirectionForced(
				currentPointOutwards, lastOrientation,
				nextPointOutwards, nextOrientation);



			Vector2 leftPoint;
			Vector2 rightPoint;
			if (isLeftCurve)
			{
				leftPoint = innerIntersection;
				rightPoint = outerIntersection;
			}
			else
			{
				leftPoint = outerIntersection;
				rightPoint = innerIntersection;
			}
			polygonPoints[index] = leftPoint;
			polygonPoints[2 * count - 1 - index] = rightPoint;
			// polygonPoints[index] = isLeftCurve ? innerIntersection : outerIntersection;
			// polygonPoints[2 * count - 1 - index] = isLeftCurve ? outerIntersection : innerIntersection;

			// Assign values needed next round
			lastOrientation = nextOrientation;
		}

		return polygonPoints;
	}

	public static Vector2[] GaalopOld(Vector2[] linePoints, float halfWidth)
	{
		List<Vector2> leftPoints = new();
		List<Vector2> rightPoints = new();

		// Iterate points
		for (int index = 0; index < linePoints.Length - 2; index++)
		{
			Vector2 lastPoint = linePoints[index];
			Vector2 point = linePoints[index + 1];
			Vector2 nextPoint = linePoints[index + 2];

			Vector2 lastToCurrent = point - lastPoint;
			float lastOrientation = lastToCurrent.Orientation().NormalizeAngle();

			float nextOrientation = (nextPoint - point).Orientation();
			bool isLeftCurve = (nextOrientation - lastOrientation).NormalizeAngle() is > 0 and < Mathf.Pi;

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

		leftPoints.Reverse();
		Vector2[] polygonPoints = rightPoints.Concat(leftPoints).ToArray();
		return polygonPoints;
	}

	public static Vector2[] GaalopNew(Vector2[] linePoints, float halfWidth)
	{
		float firstLine__e0;
		float firstLine__e1;
		float firstLine__e2;
		float firstLineLength;
		float firstLine_e0;
		float firstLine_e1 = 0;
		float firstLine_e2 = 0;
		float firstLineLeft_e0 = 0;
		float firstLineRight_e0 = 0;

		// Number of loops
		int count = linePoints.Count() - 2;

		Vector2[] polygonPoints = new Vector2[2 * count];

		for (int index = 0; index < count; index++)
		{
			Vector2 lastPoint = linePoints[index];
			Vector2 point = linePoints[index + 1];
			Vector2 nextPoint = linePoints[index + 2];

			float ax = lastPoint.X;
			float ay = lastPoint.Y;
			float bx = point.X;
			float by = point.Y;
			float cx = nextPoint.X;
			float cy = nextPoint.Y;

			if (index == 0)
			{
				firstLine__e0 = ax * by - ay * bx;
				firstLine__e1 = -by + ay;
				firstLine__e2 = bx - ax;
				firstLineLength = MathF.Sqrt(firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2) / (firstLine__e1 * firstLine__e1 + firstLine__e2 * firstLine__e2); // Simplified
				firstLine_e0 = firstLine__e0 * firstLineLength;
				firstLine_e1 = firstLine__e1 * firstLineLength;
				firstLine_e2 = firstLine__e2 * firstLineLength;
				firstLineLeft_e0 = firstLine_e0 - halfWidth;
				firstLineRight_e0 = firstLine_e0 + halfWidth;
			}

			float secondLine__e0 = bx * cy - by * cx;
			float secondLine__e1 = -cy + by;
			float secondLine__e2 = cx - bx;
			float secondLineLength = MathF.Sqrt(secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2) / (secondLine__e1 * secondLine__e1 + secondLine__e2 * secondLine__e2);
			float secondLine_e0 = secondLine__e0 * secondLineLength;
			float secondLine_e1 = secondLine__e1 * secondLineLength;
			float secondLine_e2 = secondLine__e2 * secondLineLength;
			float secondLineLeft_e0 = secondLine_e0 - halfWidth;
			float secondLineRight_e0 = secondLine_e0 + halfWidth;
			float secondPointLeft_e01 = firstLineLeft_e0 * secondLine_e1 - firstLine_e1 * secondLineLeft_e0;
			float secondPointLeft_e02 = firstLineLeft_e0 * secondLine_e2 - firstLine_e2 * secondLineLeft_e0;
			float secondPointLeft_e12 = firstLine_e1 * secondLine_e2 - firstLine_e2 * secondLine_e1;
			float secondPointRight_e01 = firstLineRight_e0 * secondLine_e1 - firstLine_e1 * secondLineRight_e0;
			float secondPointRight_e02 = firstLineRight_e0 * secondLine_e2 - firstLine_e2 * secondLineRight_e0;
			float secondPointRight_e12 = firstLine_e1 * secondLine_e2 - firstLine_e2 * secondLine_e1;

			Vector2 left = new(-secondPointLeft_e02 / secondPointLeft_e12, secondPointLeft_e01 / secondPointLeft_e12);
			Vector2 right = new(-secondPointRight_e02 / secondPointRight_e12, secondPointRight_e01 / secondPointRight_e12);

			polygonPoints[index] = left;
			polygonPoints[2 * count - 1 - index] = right;

			// Assign known values for the next loop
			firstLine_e1 = secondLine_e1;
			firstLine_e2 = secondLine_e2;
			firstLineLeft_e0 = secondLineLeft_e0;
			firstLineRight_e0 = secondLineRight_e0;
		}

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
		temp_gcse_5 = Abs(temp_gcse_2);
		temp_gcse_9 = Sqrt(temp_gcse_5);
		temp_gcse_15 = Sqrt(Abs(temp_gcse_4));
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
		temp_gcse_1 = Sqrt(Abs((lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]) * (lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3])));
		temp_gcse_7 = Abs(lineBC_[2] * lineBC_[2] + lineBC_[3] * lineBC_[3]);
		temp_gcse_10 = Sqrt(temp_gcse_7);
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

	static float Sqrt(float value) => Mathf.Sqrt(value);

	static float Abs(float value) => Mathf.Abs(value);

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