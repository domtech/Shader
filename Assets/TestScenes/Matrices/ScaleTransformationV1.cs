using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransformationV1 : TransformationV1 {
    public Vector3 m_vScale;
    public override Vector3 Apply(Vector3 point)
    {
        point.x *= m_vScale.x;
        point.y *= m_vScale.y;
        point.z *= m_vScale.z;

        return point;
    }
}
