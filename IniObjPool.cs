using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniObjPool : MonoBehaviour {

    public int numberOfObjs = 6;

    public GameObject Tiro;
    private List<GameObject> TiroList;

    void Start()
    {
        TiroList = new List<GameObject>();
    }
    ///////////     Aramas     ///////////////
    public GameObject Atirar()
    {
        int numberOfObjs = TiroList.Count;
        for (int i = 0; i < numberOfObjs; i++)
        {
            if (!TiroList[i].activeInHierarchy)
                return TiroList[i];
        }
        GameObject obj = Instantiate(Tiro);
        obj.SetActive(true);
        TiroList.Add(obj);
        return obj;
    }
}
