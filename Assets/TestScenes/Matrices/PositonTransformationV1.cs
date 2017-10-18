using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositonTransformationV1 : TransformationV1 {
    public Vector3 m_vpos;
    public override Vector3 Apply(Vector3 point)
    {
        
        return point + m_vpos;
    }



}
