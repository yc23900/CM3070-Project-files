using UnityEngine;

public class SafeAreaOnPlane : MonoBehaviour
{
    public GameOverScreen gameOverScreen; 
    public Vector2 safeAreaSize = new Vector2(5, 5); 

    private LineRenderer lineRenderer;

    void Start()
    {
       
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.loop = true;
        lineRenderer.positionCount = 5;

       //color correction
        Material lineMaterial = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material = lineMaterial;

        DrawBoundaryLines();
    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Block") && other.attachedRigidbody != null)
        {
           
            Vector3 blockPosition = other.transform.position;
            Vector2 blockPos2D = new Vector2(blockPosition.x, blockPosition.z);

          
            if (!IsWithinSafeArea(blockPos2D))
            {
                
                gameOverScreen.TriggerGameOver();
            }
        }
    }

    bool IsWithinSafeArea(Vector2 position)
    {
        Vector2 halfSize = safeAreaSize / 2;

       
        return (position.x >= -halfSize.x && position.x <= halfSize.x &&
                position.y >= -halfSize.y && position.y <= halfSize.y);
    }

    void DrawBoundaryLines()
    {
        
        Vector2 halfSize = safeAreaSize / 2;


        Vector3[] positions = new Vector3[5];
        positions[0] = new Vector3(-halfSize.x, 0.01f, -halfSize.y);
        positions[1] = new Vector3(halfSize.x, 0.01f, -halfSize.y);
        positions[2] = new Vector3(halfSize.x, 0.01f, halfSize.y);
        positions[3] = new Vector3(-halfSize.x, 0.01f, halfSize.y);
        positions[4] = positions[0]; 

      
        lineRenderer.SetPositions(positions);
    }
}