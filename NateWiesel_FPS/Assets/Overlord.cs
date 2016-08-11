using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Overlord : MonoBehaviour {

    private static Overlord instance;
    
    public static  Overlord Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Overlord();
            }
            return instance;
        }
    }

    GameObject[] guns;
    int _selectedGun;
    int _maxSelectedGun;
    int SelectedGun
    {
        get
        {
            return _selectedGun;
        }
    }


    void FindGuns()
    {
        guns = GameObject.FindGameObjectsWithTag("Weapon");

        int ind = 0;
        foreach (GameObject gun in guns)
        {
            if (ind == SelectedGun)
            {
                gun.SetActive(true);
            }
            else
            {
                gun.SetActive(false);
            }

            ind++;
        }

        _maxSelectedGun = guns.Length;
    }

	// Use this for initialization
	void Start () {
        FindGuns();
    }
	
	// Update is called once per frame
	void Update () {
        FindGuns();

        if (Input.GetKeyDown("q"))
        {
            _selectedGun--;
        }
        else if (Input.GetKeyDown("e"))
        {
            _selectedGun++;
        }
        if (_selectedGun < 0) _selectedGun = 0;
        if (_selectedGun > _maxSelectedGun) _selectedGun = _maxSelectedGun;
    }
}
