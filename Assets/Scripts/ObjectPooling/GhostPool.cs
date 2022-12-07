using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPool : MonoBehaviour
{
    public GameObject ghostPrefab;
    List<GameObject> pool = new List<GameObject>();
    public int numOfGhosts = 50;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numOfGhosts; i++)
        {
            GameObject newGhost = Instantiate<GameObject>(ghostPrefab);
            newGhost.SetActive(false);
            pool.Add(newGhost);
        }
    }

    GameObject CreateGhost()
    {
        foreach (GameObject ghost in pool)
        {
            if (!ghost.activeSelf)
            {
                ghost.SetActive(true);
                ghost.transform.position = transform.position;
                return ghost;
            }
        }

        GameObject newGhost = Instantiate<GameObject>(ghostPrefab);
        pool.Add(newGhost);

        return newGhost;
    }

    void RemoveGhost()
    {
        foreach (GameObject ghost in pool)
        {
            if (ghost.activeSelf)
            {
                ghost.SetActive(false);
                return;
            }
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            CreateGhost();
        if (Input.GetKeyDown(KeyCode.O))
            RemoveGhost();

        Debug.Log("Pool Size = " + pool.Count.ToString());
    }
}
