using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Character;
    public GameObject FloorPrefab;
    public GameObject Camera;
    public GameObject Capsule;
    private int lastFloorZ = 0;
    private bool canvasSet = false;
    public TMP_Text GameOverText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lastFloorZ < Character.transform.position.z + 80)
        {
            lastFloorZ += 10;
            if (Random.value > 0.3f)
            {
                Instantiate(FloorPrefab, new Vector3(0, 0, lastFloorZ), Quaternion.identity);
            }
            Instantiate(FloorPrefab, new Vector3(-3, 0, lastFloorZ), Quaternion.identity);
            Instantiate(FloorPrefab, new Vector3(3, 0, lastFloorZ), Quaternion.identity);
            RandomCapsuleInstantiate();
        }

        foreach (var oldFloor in GameObject.FindGameObjectsWithTag("Floor").Where(x => x.transform.position.z < Character.transform.position.z - 20))
        {
            Destroy(oldFloor);
        }

        Vector3 temp = Character.transform.position;
        temp.y += 3;
        temp.z = temp.z - 5;
        // Assign value to Camera position
        Camera.transform.position = temp;
        
        if (Character.transform.position.y < -5 && !canvasSet)
        {
            GameOverText.text = "Game Over!";
        }
        if (Character.transform.position.y < -30)
        {
            SceneManager.LoadScene("RunRunRunScene");
        }
    }

    void RandomCapsuleInstantiate()
    {
        if (Random.Range(0, 100) > 70)
        {
            Instantiate(Capsule, new Vector3(Random.Range(-1, 1) * 3, 1, lastFloorZ), Quaternion.identity);
        }
    }
}
