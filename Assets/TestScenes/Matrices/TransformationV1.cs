using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformationV1 : MonoBehaviour {
    public abstract Vector3 Apply(Vector3 point);
}
