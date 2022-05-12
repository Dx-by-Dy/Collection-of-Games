using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_table_mode : MonoBehaviour
{
    public void Change_active_rule()
    {
        GameObject Rule_table = GameObject.Find("Canvas").gameObject.transform.Find("Rule_table").gameObject;
        if (Rule_table.activeSelf == true) Rule_table.SetActive(false);
        else Rule_table.SetActive(true);
    }

}
