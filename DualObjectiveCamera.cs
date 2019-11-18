using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class for defining two players and assigns them to the camera so that it follows them
public class DualObjectiveCamera : MonoBehaviour
{
    static public DualObjectievCamera instance;

    public Transform leftTarget;
    public Transform rightTarget;

    [SerializeField]
    bool start = false;

    public float minDistance;
    public float maxDistance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        leftTarget = p.transform;

        p = GameObject.FindGameObjectWithTag("Oponent");
        rightTarget = p.transform;
        
        Invoke("StartCamera", 0.1f);
    }
    void LateUpdate()
    {
        if (start)
        {
            CameraPosition();
        }
    }

    void StartCamera()
    {
        start = true;
    }

    void CameraPosition()
    {
        float distanceBetweenTargets = Mathf.Abs(leftTarget.transform.position.x - rightTarget.transform.position.x) * 2;
        float centerPosition = (leftTarget.transform.position.x + rightTarget.transform.position.x) / 2;

        transform.position = new Vector3
            (
            centerPosition , 
            transform.position.y,
            distanceBetweenTargets > minDistance ? distanceBetweenTargets < maxDistance ? -distanceBetweenTargets : -maxDistance : -minDistance   
            );
    }
}
