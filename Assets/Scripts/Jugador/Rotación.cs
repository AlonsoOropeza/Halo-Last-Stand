using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotación : MonoBehaviour
{
    [SerializeField] Transform camara;
    [SerializeField] float sensibilidad;
    float rotarCabeza = 0f;
    [SerializeField] float rotarCabezaLimite = 90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime * -1f;
        transform.Rotate(0f, x, 0f);
        rotarCabeza += y;
        rotarCabeza = Mathf.Clamp(rotarCabeza, -rotarCabezaLimite, rotarCabezaLimite);
        camara.localEulerAngles = new Vector3(rotarCabeza, 0f, 0f);
    }
}
