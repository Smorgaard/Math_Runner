using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Level : MonoBehaviour
{
    public GameObject[] section;
    public int z_Pos = 50;
    public bool creating_section = false;
    public int section_number;
    
    
    void Update()
    {
        if (creating_section == false)
        {
            creating_section = true;
            StartCoroutine(Generate_Section());
        }    
    }

    IEnumerator Generate_Section()
    {
        section_number = Random.Range(0, 1);
        Instantiate(section[section_number], new Vector3(0, 0, z_Pos), Quaternion.identity);
        z_Pos += 50;
        yield return new WaitForSeconds(2);
        creating_section = false;
    }
}
