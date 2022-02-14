using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Transform canvas;
    public static GameObject player;
    public static Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
