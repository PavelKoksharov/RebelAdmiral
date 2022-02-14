using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position -= new Vector3(speed, 0, 0);
    }
}
