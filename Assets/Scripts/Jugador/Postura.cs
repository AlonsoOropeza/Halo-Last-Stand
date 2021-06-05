using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postura : MonoBehaviour
{
    [SerializeField] float crouch;
    bool crouched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouched)
            {
                transform.position += new Vector3(0, crouch, 0);
                crouched = false;
            }
            else
            {
                transform.position -= new Vector3(0, crouch, 0);
                crouched = true;
            }
        }
    }
 }
