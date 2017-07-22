using UnityEngine;
using System.Collections;

public class TurnObject : MonoBehaviour
{
    [SerializeField]
    private int m_AxisX;
    [SerializeField]
    private int m_AxisY;
    [SerializeField]
    private int m_AxisZ;

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(new Vector3(m_AxisX, m_AxisY, m_AxisZ) * Time.deltaTime);
	}
}
