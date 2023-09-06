using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticle : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public float moveSpeed = 1.0f;
    public float maxHeight = 10.0f;
    public float minHeight = 1.0f;

    private GameObject selectedObject;

    void Start()
    {
        // Start the coroutine to change the selected object every 3 seconds
        StartCoroutine(ChangeObjectPeriodically());
    }

    IEnumerator ChangeObjectPeriodically()
    {
        while (true)
        {
            // Randomly select one of the two objects
            if (Random.Range(0, 2) == 0)
            {
                selectedObject = object1;
            }
            else
            {
                selectedObject = object2;
            }

            // Wait for 3 seconds before changing the object again
            yield return new WaitForSeconds(3f);

            // Send the selected object back down after 3 seconds
            StartCoroutine(MoveObjectDown(selectedObject, 3f));
        }
    }

    IEnumerator MoveObjectDown(GameObject obj, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startPos = obj.transform.position;
        Vector3 endPos = new Vector3(startPos.x, minHeight, startPos.z);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            obj.transform.position = Vector3.Lerp(startPos, endPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is at the desired position
        obj.transform.position = endPos;
    }

    void Update()
    {
        // Move the selected object upward along the Y-axis
        if (selectedObject != null)
        {
            Vector3 newPosition = selectedObject.transform.position + Vector3.up * moveSpeed * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, minHeight, maxHeight);
            selectedObject.transform.position = newPosition;
        }
    }
}
