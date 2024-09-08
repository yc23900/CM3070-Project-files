using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float moveIncrement = 0.0f;
    public float moveSpeed = 0.05f; 
    public float moveDelay = 1.0f; 
    private float lastMoveTime = 0f; 

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Time.time >= lastMoveTime + moveDelay)
        {
            MoveCameraUp();
        }
    }

    private void MoveCameraUp()
    {
      
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + moveIncrement, transform.position.z);
        StartCoroutine(MoveToPosition(newPos, moveSpeed));
        lastMoveTime = Time.time; 
    }

    IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, target, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
    }
}