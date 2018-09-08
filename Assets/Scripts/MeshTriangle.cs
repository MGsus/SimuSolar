using UnityEngine;

public class MeshTriangle : MonoBehaviour {

    public Vector3 leftTopFront = new Vector3(-1, 1, 1);
    public Vector3 rightTopFront = new Vector3(-1, 1, 1);
    public Vector3 leftBottomFront = new Vector3(1, 1, 1);
    public Vector3 rightBottomFront = new Vector3(-1, -1, 1);
    public Vector3 leftTopBack = new Vector3(1, 1, 1);
    public Vector3 rightTopBack = new Vector3(1, 1, 1);
    public Vector3 leftBottomBack = new Vector3(1, 1, 1);
    public Vector3 rightBottomBack = new Vector3(1, 1, 1);

    // Use this for initialization
    private void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        var mesh = meshFilter.mesh;
        var vertices = new Vector3[]
        {
            // Front face
            leftTopFront,
            rightTopFront,
            leftBottomFront,
            rightBottomFront,

            //Back face
            leftTopBack,
            rightTopBack,
            leftBottomBack,
            rightBottomBack
        };

        var triangle = new int[]
        {
            // Front face
            0, 2, 3,
            3, 1, 0,

            // Back face
            4, 6, 7,
            7, 5, 4,

            // Left face
            8, 10, 11,
            11, 9, 8,

            // Right face
            12,14,15,
            15,13,12,
            
            // Top face
            16,18,19,
            19,17,16,
            
            // Bottom face
            20,22,23,
            23,21,20
        };

        var uvs = new Vector2[]
        {
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0), 
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
            
        };
        
        mesh.Clear();
        mesh.vertices = vertices;
    }
	
    // Update is called once per frame
    void Update () {
		
    }
}