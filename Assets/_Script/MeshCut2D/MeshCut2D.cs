using System.Collections.Generic;
using UnityEngine;

public class MeshCut2D
{
    public static void Cut(
        IList<Vector3> vertices,
        IList<Vector2> uv,
        IList<int> indices,
        int indexCount,
        float x1, // LinePoint1
        float y1, // LinePoint1
        float x2, // LinePoint2
        float y2, // LinePoint2
        MeshCutResult _resultsA,
        MeshCutResult _resultsB)
    {
        _resultsA.Clear();
        _resultsB.Clear();

        for (int i = 0; i < indexCount; i += 3)
        {
            int indexA = indices[i + 0];
            int indexB = indices[i + 1];
            int indexC = indices[i + 2];
            Vector3 a = vertices[indexA];
            Vector3 b = vertices[indexB];
            Vector3 c = vertices[indexC];
            float uvA_X = uv[indexA].x;
            float uvA_Y = uv[indexA].y;
            float uvB_X = uv[indexB].x;
            float uvB_Y = uv[indexB].y;
            float uvC_X = uv[indexC].x;
            float uvC_Y = uv[indexC].y;

            bool aSide = IsClockWise(x1, y1, x2, y2, a.x, a.y);
            bool bSide = IsClockWise(x1, y1, x2, y2, b.x, b.y);
            bool cSide = IsClockWise(x1, y1, x2, y2, c.x, c.y);
            if (aSide == bSide && aSide == cSide)
            {
                var triangleResult = aSide ? _resultsA : _resultsB;
                triangleResult.AddTriangle(
                    a.x, a.y, b.x, b.y, c.x, c.y,
                    uvA_X, uvA_Y, uvB_X, uvB_Y, uvC_X, uvC_Y);
            }
            else if (aSide != bSide && aSide != cSide)
            {
                float abX, abY, caX, caY, uvAB_X, uvAB_Y, uvCA_X, uvCA_Y;
                GetIntersectionLineAndLineStrip(
                    x1, y1, x2, y2, a.x, a.y, b.x, b.y, uvA_X, uvA_Y, uvB_X, uvB_Y,
                    out abX, out abY, out uvAB_X, out uvAB_Y);
                GetIntersectionLineAndLineStrip(
                    x1, y1, x2, y2, c.x, c.y, a.x, a.y, uvC_X, uvC_Y, uvA_X, uvA_Y,
                    out caX, out caY, out uvCA_X, out uvCA_Y);
                var triangleResult = aSide ? _resultsA : _resultsB;
                var rectangleResult = aSide ? _resultsB : _resultsA;
                triangleResult.AddTriangle(a.x, a.y, abX, abY, caX, caY,
                    uvA_X, uvA_Y, uvAB_X, uvAB_Y, uvCA_X, uvCA_Y);
                rectangleResult.AddRectangle(b.x, b.y, c.x, c.y, caX, caY, abX, abY,
                    uvB_X, uvB_Y, uvC_X, uvC_Y, uvCA_X, uvCA_Y, uvAB_X, uvAB_Y);
            }
            else if (bSide != aSide && bSide != cSide)
            {
                float abX, abY, bcX, bcY, uvAB_X, uvAB_Y, uvBC_X, uvBC_Y;
                GetIntersectionLineAndLineStrip(
                    x1, y1, x2, y2, a.x, a.y, b.x, b.y, uvA_X, uvA_Y, uvB_X, uvB_Y,
                    out abX, out abY, out uvAB_X, out uvAB_Y);
                GetIntersectionLineAndLineStrip(
                    x1, y1, x2, y2, b.x, b.y, c.x, c.y, uvB_X, uvB_Y, uvC_X, uvC_Y,
                    out bcX, out bcY, out uvBC_X, out uvBC_Y);
                var triangleResult = bSide ? _resultsA : _resultsB;
                var rectangleResult = bSide ? _resultsB : _resultsA;
                triangleResult.AddTriangle(
                    b.x, b.y, bcX, bcY, abX, abY,
                    uvB_X, uvB_Y, uvBC_X, uvBC_Y, uvAB_X, uvAB_Y);
                rectangleResult.AddRectangle(
                    c.x, c.y, a.x, a.y, abX, abY, bcX, bcY,
                    uvC_X, uvC_Y, uvA_X, uvA_Y, uvAB_X, uvAB_Y, uvBC_X, uvBC_Y);
            }
            else if (cSide != aSide && cSide != bSide)
            {
                float bcX, bcY, caX, caY, uvBC_X, uvBC_Y, uvCA_X, uvCA_Y;
                GetIntersectionLineAndLineStrip(
                    x1, y1, x2, y2, b.x, b.y, c.x, c.y, uvB_X, uvB_Y, uvC_X, uvC_Y,
                    out bcX, out bcY, out uvBC_X, out uvBC_Y);
                GetIntersectionLineAndLineStrip(
                    x1, y1, x2, y2, c.x, c.y, a.x, a.y, uvC_X, uvC_Y, uvA_X, uvA_Y,
                    out caX, out caY, out uvCA_X, out uvCA_Y);
                var triangleResult = cSide ? _resultsA : _resultsB;
                var rectangleResult = cSide ? _resultsB : _resultsA;
                triangleResult.AddTriangle(
                    c.x, c.y, caX, caY, bcX, bcY,
                    uvC_X, uvC_Y, uvCA_X, uvCA_Y, uvBC_X, uvBC_Y);
                rectangleResult.AddRectangle(
                    a.x, a.y, b.x, b.y, bcX, bcY, caX, caY,
                    uvA_X, uvA_Y, uvB_X, uvB_Y, uvBC_X, uvBC_Y, uvCA_X, uvCA_Y);
            }
        }
    }

    private static void GetIntersectionLineAndLineStrip(
        float x1, float y1, // Line Point
        float x2, float y2, // Line Point
        float x3, float y3, // Line Strip Point
        float x4, float y4, // Line Strip Point
        float uv3_X, float uv3_Y,
        float uv4_X, float uv4_Y,
        out float x, out float y,
        out float uvX, out float uvY)
    {
        float s1 = (x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1);
        float s2 = (x2 - x1) * (y1 - y4) - (y2 - y1) * (x1 - x4);

        float c = s1 / (s1 + s2);

        x = x3 + (x4 - x3) * c;
        y = y3 + (y4 - y3) * c;

        uvX = uv3_X + (uv4_X - uv3_X) * c;
        uvY = uv3_Y + (uv4_Y - uv3_Y) * c;
    }

    private static bool IsClockWise(
        float x1, float y1,
        float x2, float y2,
        float x3, float y3)
    {
        return (x2 - x1) * (y3 - y2) - (y2 - y1) * (x3 - x2) > 0;
    }
}