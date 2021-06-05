using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    private NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        var target = GameObject.Find("Player").transform.position;
        agente.destination = target;
        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        //transform.Rotate(new Vector3(0, 90, 0));
     
    }
}
