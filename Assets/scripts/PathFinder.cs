using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PathFinder : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination;
    public NavMeshPath path;
    public Vector3[] corners;
    public Transform[] spheres;
    public Transform Arrow;
    public float radius = 0.08f;
    public LineRenderer line;
    void Start()
    {
        line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination.position);
        corners = agent.path.corners;
        Vector3 lookPosition = corners[0];
        lookPosition.y = Arrow.transform.position.y;
        Arrow.LookAt(lookPosition);
        //line.positionCount = corners.Length;
        if(Input.GetKeyDown(KeyCode.Space)){
             line.positionCount = corners.Length+1;
             Vector3 position = this.transform.position;
             position.y = 0.05f;
             line.SetPosition(0,position);
            
            for(int i = 0; i < corners.Length;i++){
                corners[i].y = 0.05f;
                line.SetPosition(i+1,corners[i]);
             }
        }
    }
    void OnDrawGizmos(){
        foreach(Vector3 corner in corners){
            Gizmos.DrawSphere(corner,radius);
        }
    }
}
