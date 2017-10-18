using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationGridV1 : MonoBehaviour {
    public Transform m_tPrefab;
    public int m_igrigResolution;
    Transform[] Grid;
    List<TransformationV1> transformation;
    #region 系统接口
    private void Awake()
    {
        //初始化
        Grid = new Transform[m_igrigResolution * m_igrigResolution * m_igrigResolution];
        transformation = new List<TransformationV1>();

        ///*Visualizing Space
        ////初始化grid
        // Grid = new Transform[m_igrigResolution * m_igrigResolution * m_igrigResolution];
        for (int i = 0, x = 0; x < m_igrigResolution; x++)
        {
            for (int y = 0; y < m_igrigResolution; y++)
            {
                for (int z = 0; z < m_igrigResolution; z++, i++)
                    Grid[i] = IniteGridPoints(x, y, z);
            }
        }
    }

    private void Update()
    {
        //获得所有继承自transformationV1的组件
        GetComponents<TransformationV1>(transformation);
        for (int i = 0, x = 0; x < m_igrigResolution; x++)
        {
            for (int y = 0; y < m_igrigResolution; y++)
            {
                for (int z = 0; z < m_igrigResolution; z++, i++)
                    Grid[i].localPosition= TransformPoints(x, y, z);
            }
        }
    }

    #endregion
    #region 初始化grid
    Transform IniteGridPoints(int x,int y,int z)
    {
        Transform point = Instantiate<Transform>(m_tPrefab);
        point.localPosition = GetCoordinates(x, y, z);
      //  point.parent = gameObject.transform;
        point.GetComponent<MeshRenderer>().material.color = new Color(
          (float)  x / m_igrigResolution, (float)y / m_igrigResolution, (float)z / m_igrigResolution);
        return point;
    }
    #endregion


    Vector3 GetCoordinates(int x, int y,int z)
    {
        return new Vector3(x - (m_igrigResolution + 1) / 2f,
            y - (m_igrigResolution +1) / 2f,
            z - (m_igrigResolution +1) / 2f);
    }

      
    #region transformation
    Vector3 TransformPoints(int x, int y,int z)
    {
        Vector3 coordinate = GetCoordinates(x, y, z);
        for(int i=0;i<transformation.Count;i++)
        {
            coordinate = transformation[i].Apply(coordinate);
        }
        return coordinate;
    }
#endregion
}
