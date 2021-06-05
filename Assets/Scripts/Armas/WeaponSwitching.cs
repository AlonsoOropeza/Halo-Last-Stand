using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] public int selectedWeapon;
    float municion;
    ArrayList maxAmmoForEachWeapon = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform weapon in transform)
        {
            maxAmmoForEachWeapon.Add(weapon.gameObject.GetComponent<Arma>().municion);
        }
        SelectWeapon(selectedWeapon);
        
    }

    // Update is called once per frame
    void Update()
    {
        //int previousSelectedWeapon = selectedWeapon;

        //if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        //{
        //    if( selectedWeapon >= transform.childCount -1)
        //            selectedWeapon = 0;
        //    else
        //        selectedWeapon++;
        //}

        //if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        //{
        //    if (selectedWeapon <= 0)
        //        selectedWeapon = transform.childCount - 1;
        //    else
        //        selectedWeapon--;
        //}

        //if(previousSelectedWeapon != selectedWeapon)
        //{
        //    SelectWeapon();
        //}
    }

    public void SelectWeapon(int selectedWeapon)
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                var arma = weapon.gameObject.GetComponent<Arma>();
                arma.municion = (float)maxAmmoForEachWeapon[i];
                weapon.gameObject.SetActive(true);
                HUD.Instancia.nombre_arma(arma.nombre);

            }
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}
