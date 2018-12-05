using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLinesRenderer : MonoBehaviour {

	[SerializeField] LineRenderer lineRenderer;
	public Transform[] points;
	int numPoints = 50;
	Vector3[] positions = new Vector3[50];
	

	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = numPoints;
		DrawCubicCurve();
	}
	

	void Update () {
		DrawCubicCurve();
	}

	void DrawCubicCurve()
	{
		Vector3 ouputDirection = points[0].position;
		ouputDirection.x = ouputDirection.x + 0.2f;
		Vector3 inputDirection = points[1].position;
		inputDirection.x = ouputDirection.x - 0.2f;
		
		for (int i = 1; i < numPoints + 1; i++)
		{
			float t = i / (float)numPoints;

			positions[i - 1] = CalculateCubicBezierPoint(t, points[0].position, ouputDirection, inputDirection, points[1].position);
		}
		lineRenderer.SetPositions(positions);
	}


	Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1,Vector3 p2, Vector3 p3)
	{
		float u = 1 - t;
		float tt = t * t;
		float uu = u * u;
		float uuu = uu * u;
		float ttt = tt * t;
		Vector3 p = uuu * p0;
		p += 3 * uu * t * p1;
		p += 3 * u * tt * p2;
		p += ttt * p3;
		return p;
	}

}
