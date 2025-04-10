using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject slot1, slot2, slot3;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Equip1();
        }

        if (Input.GetKeyDown("2"))
        {
            Equip2();
        }

        if (Input.GetKeyDown("3"))
        {
            Equip3();
        }
    }

    void Equip1()
    {
        slot1.SetActive(true);
        slot2.SetActive(false);
        slot3.SetActive(false);
    }

    void Equip2()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
        slot3.SetActive(false);
    }

    void Equip3()
    {
        slot1.SetActive(false);
        slot2.SetActive(false);
        slot3.SetActive(true);
    }

}
