 using UnityEngine;
 using System.Collections;
 
 public class Spherize : MonoBehaviour 
 {
     void Start () 
         {
              Mesh mesh = GetComponent<MeshFilter>().mesh;
 
             Vector3[] vertices = mesh.vertices;
 
             for (int i = 0; i < vertices.Length; i++ )
             {
                 vertices[i] = vertices[i].normalized * 5f;
             }
 
             mesh.vertices = vertices;
             mesh.RecalculateNormals();
             mesh.RecalculateBounds();
     }
 }