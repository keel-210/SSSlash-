using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeAnchor : MonoBehaviour, ISlash
{
    [SerializeField] HingeJoint hinge;
    public void Slashed(Vector2 p0, Vector2 p1, bool PlayerSide, Vector3 SlideVec)
    {
        Vector3 tmp = transform.position + GetComponent<Rigidbody>().centerOfMass;
        bool HingeSide = MeshCut2D.IsClockWise(p0.x, p0.y, p1.x, p1.y, tmp.x, tmp.y);
        if (PlayerSide && !HingeSide)
            hinge.connectedAnchor += SlideVec;
        else if (!PlayerSide && HingeSide)
            hinge.connectedAnchor += SlideVec;
    }
    public void Return()
    {
        if (hinge.connectedAnchor != new Vector3(transform.position.x, transform.position.y, 0))
            hinge.connectedAnchor -= transform.parent.position;
    }
}