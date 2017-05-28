using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
	public int numberOfObjs = 6;

    public GameObject _pistola;
    private List<GameObject> pistolaList;

	public GameObject _shotgun;
	private List<GameObject> shotgunList;

    void Start()
    {
		pistolaList = new List<GameObject>();
		shotgunList = new List<GameObject>();
    }
    ///////////     Aramas     ///////////////
    public GameObject Pistola()
    {
		int numberOfObjs = pistolaList.Count;
        for (int i = 0; i < numberOfObjs; i++)
        {
			if (!pistolaList[i].activeInHierarchy)
				return pistolaList[i];
        }
        GameObject obj = Instantiate(_pistola);
        obj.SetActive(true);
		pistolaList.Add(obj);
        return obj;
    }

	public GameObject Shotgun()
	{
		int numberOfObjs = shotgunList.Count;
		for (int i = 0; i < numberOfObjs; i++)
		{
			if (!shotgunList[i].activeInHierarchy)
				return shotgunList[i];
		}
		GameObject obj = Instantiate(_shotgun);
		obj.SetActive(true);
		shotgunList.Add(obj);
		return obj;
	}
}
