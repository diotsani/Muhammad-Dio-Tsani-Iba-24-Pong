using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxPowerUpAmount;
    public List<GameObject> powerUpTemplateList;

    public List<GameObject> powerUpList;

    public Transform spawnArea;
    public Vector2 powerUpAreaMax;
    public Vector2 powerUpAreaMin;

    public int spawnInterval;
    private float timer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if(powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if(position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x || position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public IEnumerator AutoRemovePowerUp(GameObject powerUp)
    {
        yield return new WaitForSeconds(7);
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while(powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
