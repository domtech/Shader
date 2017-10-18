using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTransformationV1 : TransformationV1 {
    public Vector3 m_vRotation;
    public override Vector3 Apply(Vector3 point)
    {
        //转换为弧度制
        float radz = m_vRotation.z * Mathf.Deg2Rad;
        float rady = m_vRotation.y * Mathf.Deg2Rad;
        float radx = m_vRotation.x * Mathf.Deg2Rad;
        float cosz = Mathf.Cos(radz);
        float sinz = Mathf.Sin(radz);
        float cosy = Mathf.Cos(rady);
        float siny = Mathf.Sin(rady);
        float cosx = Mathf.Cos(radx);
        float sinx = Mathf.Sin(radx);
        Vector3 xAxis = new Vector3(
            cosy * cosz,
            cosx * sinz + sinx * siny * cosz,
            sinx * sinz - cosx * siny * cosz
        );
        Vector3 yAxis = new Vector3(
            -cosy * sinz,
            cosx * cosz - sinx * siny * sinz,
            sinx * cosz+ cosx * siny * sinz
        );
        Vector3 zAxis = new Vector3(
            siny,
            -sinx * cosy,
            cosx * cosy
        );
        return point.x*xAxis+point.y*yAxis+point.z*zAxis;
    }
}
