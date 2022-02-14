using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer mLineRenderer;
    public GameObject laser;
    private Camera cam;

    private Transform target;
    //public GameObject targetTool;

    private void Start()
    {
        
        //cam = Main.cam;
        //if (GameObject.FindGameObjectWithTag("Target") != null)
        //{
        //    targetObj = GameObject.FindGameObjectWithTag("Target");
        //    target = targetObj.transform;

        //    Vector3 targetPos = new Vector3(target.transform.position.x + 50.0f,
        //                                    target.position.y + 20 - Random.Range(0, 50),
        //                                    target.position.z);

        //    else if (typeOfAmmo == "Laser")
        //    {
        //        DrawRay(targetPos, player.transform.position);
        //        target.transform.parent.GetComponent<EnemyShip>().EnemyTakeDamage(1);
        //        Destroy(gameObject, 0.7f);
        //    }
    }

    void DrawRay(Vector3 startPos, Vector3 endPos)
    {
        mLineRenderer.SetPosition(0, startPos);
        mLineRenderer.SetPosition(1, endPos);
    }

    private void Update()
    {
    }
}
