using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Overlord : MonoBehaviour {

    private static Overlord instance;
    
    public static  Overlord Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Overlord>();
            }
            return instance;
        }
    }

    public GameObject[] gunObjects;

    int _selectedGun;
    int _maxSelectedGun;
    public GameObject SelectedGun
    {
        get
        {
            if (gunObjects.Length > 0)
            {
                return gunObjects[_selectedGun];
            }
            else return null;
        }
    }
    void FindGuns()
    {
        int ind = 0;
        foreach (GameObject gun in gunObjects)
        {
            if (ind == _selectedGun)
            {
                gun.SetActive(true);
            }
            else
            {
                gun.SetActive(false);
            }

            ind++;
        }

        _maxSelectedGun = gunObjects.Length-1;
    }
    void SwitchGuns()
    {
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

	// Use this for initialization
	void Start () {
        FindGuns();
    }
	
	// Update is called once per frame
	void Update () {
        FindGuns();
        SwitchGuns();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
