using UnityEngine;

public class MeshTriangle : MonoBehaviour {
    
    public Vector3 leftTopFront = new Vector3(-1, 1, 1);
    public Vector3 rightTopFront = new Vector3(1, 1, 1);
    public Vector3 rightTopBack = new Vector3(1, 1, -1);
    public Vector3 leftTopBack = new Vector3(-1, 1, -1);
    
    // Use this for initialization
    private void Start()
    {
        var meshFilter = GetComponent<MeshFilter>();
        var mesh = meshFilter.mesh;
        var vertices = new Vector3[]
        {
            // Front face
            leftTopFront, // 0
            rightTopFront, // 1
            new Vector3(-1, -1, 1), //2
            new Vector3(1, -1, 1), // 3
            // Back face
            rightTopBack, // 4
            leftTopBack, // 5
            new Vector3(1, -1, -1), // 6
            new Vector3(-1, -1, -1), // 7
            // Left face
            leftTopBack, //8
            leftTopFront, // 9
            new Vector3(-1, -1, -1), // 10
            new Vector3(-1, -1, 1), // 11
            // Right face
            rightTopFront, // 12
            rightTopBack, // 13
            new Vector3(), // 14
            new Vector3(), // 15
            // Top face
            leftTopBack, // 16
            rightTopBack, // 17
            leftTopFront, // 18
            rightTopFront, // 19
            // Bottom face
            new Vector3(-1, -1, 1), // 20
            new Vector3(1, -1, 1), // 21
            new Vector3(-1, -1, -1), // 22
            new Vector3(1, -1, -1) // 23
        };

        var triangles = new int[]
        {
            // Front face
            0, 2, 3, // First triangle
            3, 1, 0, // Second triangle

            // Back face
            4, 6, 7,
            7, 5, 4,

            // Left face
            8, 10, 11,
            11, 9, 8,

            // Right face
            12, 14, 15,
            15, 13, 12,

            // Top face
            16, 18, 19,
            19, 17, 16,

            // Bottom face
            20, 22, 23,
            23, 21, 20
        };

        var uvs = new Vector2[]
        {
            // Front face
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(1, 0),
            // Back Face
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(1, 0),
            // Left face
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(1, 0),
            // Right face
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(1, 0),
            // Top face
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(1, 0),
            // Bottom face
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 1),
            new Vector2(1, 0)
        };
        
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
	
    // Update is called once per frame
    void Update () {
		
    }
}