using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {
    public GameObject[] m_enemy = null;
    public float[] m_enemyInterval = new float[3];
    float[] m_enemyTimer = new float[3];

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < m_enemy.Length; i++)
        {
            m_enemyTimer[i] = m_enemyInterval[i];
        }
    }
    //public GameObject[] toSpawn;
    //public float[] spawnTime;

    //private float[] _spawnTime;

	// Use this for initialization
	//void Start () {
 //       for(int ind = 0; ind <= toSpawn.Length; ind++)
 //       {
 //           _spawnTime[ind] = spawnTime[ind];
 //       }
 //       //_spawnTime = spawnTime;

 //       if (toSpawn.Length != spawnTime.Length)
 //       {
 //           Debug.Log("enemy spawn array error");
 //       }
	//}
	
	// Update is called once per frame
	void Update () {
        //   int ind = 0;
        //foreach(GameObject goo in toSpawn)
        //   {
        //       _spawnTime[ind] -= Time.deltaTime;
        //       if (_spawnTime[ind] < 0f) {
        //           GameObject go = GameObject.Instantiate(toSpawn[ind]);
        //           go.transform.position = transform.position;
        //           _spawnTime[ind] = spawnTime[ind];
        //       }
        //       ind++;
        //   }

        for (int i = 0; i < m_enemy.Length; i++)
        {
            m_enemyTimer[i] -= Time.fixedDeltaTime;
            if (m_enemyTimer[i] <= 0)
            {
                m_enemyTimer[i] = m_enemyInterval[i];
                GameObject.Instantiate(m_enemy[i],transform.position,transform.rotation);
            }
        }
    }
}
