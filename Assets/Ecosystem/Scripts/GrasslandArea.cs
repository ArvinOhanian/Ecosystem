using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using TMPro;

public class GrasslandArea : MonoBehaviour
{
    public RabbitAgent rabbitAgent; //creates variable to track rabbits

    public TextMeshPro cumulativeRewardText; //creates variable to track score text

    public GameObject bushPrefab; //creates the bush as a game object

    public List<GameObject> bushList;

    int num_bushes = 5;

    public void ResetArea()
    {
        RemoveAllBushes();
        PlaceRabbit();
        SpawnBushes();
    }

    public void RemoveSpecificBush(GameObject bushObject)
    {
        bushList.Remove(bushObject);
        Destroy(bushObject);
    }

    public int BushesRemaining
    {
        get { return bushList.Count; }
    }

    public static Vector3 ChooseRandomPosition(Vector3 center, float minAngle, float maxAngle, float minRadius, float maxRadius)
    {
        float radius = minRadius;
        float angle = minAngle;

        if (maxRadius > minRadius)
        {
            // Pick a random radius
            radius = UnityEngine.Random.Range(minRadius, maxRadius);
        }

        if (maxAngle > minAngle)
        {
            // Pick a random angle
            angle = UnityEngine.Random.Range(minAngle, maxAngle);
        }

        // Center position + forward vector rotated around the Y axis by "angle" degrees, multiplies by "radius"
        return center + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * radius;
    }

    private void RemoveAllBushes()
    {
        if(bushList != null)
        {
            for(int i=0; i<bushList.Count; i++)
            {
                if(bushList[i] != null)
                {
                    Destroy(bushList[i]);
                }
            }
        }

        bushList = new List<GameObject>();
    }

    private void PlaceRabbit()
    {
        Rigidbody rigidbody = rabbitAgent.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rabbitAgent.transform.position = ChooseRandomPosition(transform.position, 0f, 360f, 0f, 17f) + Vector3.up * 2f;
        //rabbit can spawn anywhere
        rabbitAgent.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
        //rabbit can spawn facing any direction
    }

    private void SpawnBushes()
    {
        for (int i = 0; i < num_bushes; i++)
        {
            // Spawn and place the bush
            GameObject bushObject = Instantiate<GameObject>(bushPrefab.gameObject);
            bushObject.transform.position = ChooseRandomPosition(transform.position, 0f, 360f, 0f, 17f) + Vector3.up * 2f;
            bushObject.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);

            // Set the bush's parent to this area's transform
            bushObject.transform.SetParent(transform);

            // Keep track of the bush
            bushList.Add(bushObject);
        }
    }

    private void Start()
    {
        ResetArea();
    }

    private void Update()
    {
        cumulativeRewardText.text = rabbitAgent.GetCumulativeReward().ToString("0.00");
    }
}
