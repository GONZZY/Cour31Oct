using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


// Modifier un mesh deja existant en deformant le mesh
// Déformer -> modifier les coordonnées des sommets

// 1. Checher le mesh
// 2. Créer une copie des sommet du mesh
// 3. Modifier les sommets copiés
// 4. Donner les nouveaux sommets au mesh
// 5. Recalculate Normals
// 6. Mettre à jour le collider (sensé pour MeshCollider)
// Programmation orientée donnée: En pratique pour la déformation de sommets dans
//                                les jeux on utiliserais un SHADER. 

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class MeshDeformationTest : MonoBehaviour
{
    [Range(0f,3f)]
    [SerializeField] private float deformationQuantity = 1;

    private Mesh m;
    private MeshCollider mc;
    private void Awake()
    {
        // // 1. -->
        // Mesh m = GetComponent<MeshFilter>().mesh;
        //
        // // 2. -->
        // Vector3[] verticesCopy = m.vertices; // m.vertices retourne une copie des positions des vertices
        //
        // // 3. -->
        // for (int i = 0; i < verticesCopy.Length; i++)
        // {
        //     // Exemple 1 -->
        //     //verticesCopy[i].y += UnityEngine.Random.Range(0, 1f);
        //     // Exemple 2 -->
        //     verticesCopy[i] += m.normals[i] * Random.Range(1,deformationQuantity);
        //
        //
        // }
        //
        // // 4. -->
        // m.vertices = verticesCopy;
        //
        // // 5. -->
        // m.RecalculateNormals();
        //
        // // 6. --> (Fonctionne seulement pour les Mesh Collider)
        // GetComponent<MeshCollider>().sharedMesh = m;
        m = GetComponent<MeshFilter>().mesh;
        mc = GetComponent<MeshCollider>();

    }

    private void Update()
    {
        // 1. -->
        
        // 2. -->
        Vector3[] verticesCopy = m.vertices; // m.vertices retourne une copie des positions des vertices
        
        // 3. -->
        for (int i = 0; i < verticesCopy.Length; i++)
        {
            // Exemple 1 -->
            //verticesCopy[i].y += UnityEngine.Random.Range(0, 1f);
            // Exemple 2 -->
            verticesCopy[i] += m.normals[i] * Random.Range(0,deformationQuantity);


        }
        
        // 4. -->
        m.vertices = verticesCopy;
        
        // 5. -->
        m.RecalculateNormals();
        
        // 6. --> (Fonctionne seulement pour les Mesh Collider)
        mc.sharedMesh = m;
    }
}
