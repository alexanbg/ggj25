using UnityEngine;
using System.Collections.Generic;

public class VertexCameraDistanceCuller : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh originalMesh;
    private Mesh clonedMesh;
    private Vector3[] originalVertices;
    private int[] originalTriangles;
    private List<Vector3> visibleVertices = new List<Vector3>();
    private List<int> visibleTriangles = new List<int>();

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalMesh = meshFilter.sharedMesh;
        clonedMesh = new Mesh();
        
        originalVertices = originalMesh.vertices;
        originalTriangles = originalMesh.triangles;
        
        meshFilter.mesh = clonedMesh;
    }

    void Update()
    {
        visibleVertices.Clear();
        visibleTriangles.Clear();
        Vector3 cameraPosition = Camera.main.transform.position;

        for (int i = 0; i < originalTriangles.Length; i += 3)
        {
            Vector3 v1 = transform.TransformPoint(originalVertices[originalTriangles[i]]);
            Vector3 v2 = transform.TransformPoint(originalVertices[originalTriangles[i + 1]]);
            Vector3 v3 = transform.TransformPoint(originalVertices[originalTriangles[i + 2]]);

            // Calculate center of triangle
            Vector3 triangleCenter = (v1 + v2 + v3) / 3f;
            
            // Compare distance to camera against sphere's center
            float centerDistance = Vector3.Distance(transform.position, cameraPosition);
            float triangleDistance = Vector3.Distance(triangleCenter, cameraPosition);

            // Only show triangles that are further from camera than sphere's center
            if (triangleDistance > centerDistance)
            {
                int baseIndex = visibleVertices.Count;
                visibleVertices.Add(transform.InverseTransformPoint(v1));
                visibleVertices.Add(transform.InverseTransformPoint(v2));
                visibleVertices.Add(transform.InverseTransformPoint(v3));
                
                visibleTriangles.Add(baseIndex);
                visibleTriangles.Add(baseIndex + 1);
                visibleTriangles.Add(baseIndex + 2);
            }
        }

        clonedMesh.Clear();
        clonedMesh.vertices = visibleVertices.ToArray();
        clonedMesh.triangles = visibleTriangles.ToArray();
        clonedMesh.RecalculateNormals();
        clonedMesh.RecalculateBounds();
    }

    void OnDestroy()
    {
        if (clonedMesh != null)
            Destroy(clonedMesh);
    }
}