using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatsRadarChart : MonoBehaviour
{
    /*[SerializeField] private RectTransform CSbar;
    [SerializeField] private RectTransform ITbar;*/
    [Header("Mesh Generation Settings")]
    [SerializeField] private float radarChartSize = 45f;
    [SerializeField] private float animationSpeed;
    [SerializeField] private Vector3 CSVertex;
    [SerializeField] private Vector3 ITVertex;
    [SerializeField] private Vector3 ISVertex;
    [SerializeField] private Vector3 EMCVertex;
    [SerializeField] private Vector3 DSVertex;

    private float angleIncrement = 360f / 5;
    private Stats stats;
    private Stats statsCopy;



    [Header("References")]
    [SerializeField] private Material radarMaterial;
    [SerializeField] private CanvasRenderer radarMeshCanvasRenderer;


    public void SetStats(Stats stats)
    {
        this.stats = new Stats(0,0,0,0,0);
        statsCopy = stats;
    }

    public void ActivateAnimation()
    {
        StartCoroutine(GrowStats());
    }

    IEnumerator GrowStats()
    {
        bool CSdone = false, ITdone = false, ISdone = false, EMCdone = false, DSdone = false;

        /*Debug.Log("CS: "+ stats.Stat(Category.CS) +"; CScopy: "+ statsCopy.Stat(Category.CS)+"\n" +
                  "IT: " + stats.Stat(Category.IT) + "; CScopy: " + statsCopy.Stat(Category.IT) + "\n" +
                  "IS: " + stats.Stat(Category.IS) + "; CScopy: " + statsCopy.Stat(Category.IS) + "\n" +
                  "EMC: " + stats.Stat(Category.EMC) + "; CScopy: " + statsCopy.Stat(Category.EMC) + "\n" +
                  "DS: " + stats.Stat(Category.DS) + "; CScopy: " + statsCopy.Stat(Category.DS));
        Debug.Log(CSdone+""+ITdone+""+ISdone+""+EMCdone+""+DSdone);*/

        if (stats.Stat(Category.CS) < statsCopy.Stat(Category.CS))
        {
            stats.increaseStat(Category.CS);
        }
        else
        {
            CSdone = true;
        }

        if (stats.Stat(Category.IT) < statsCopy.Stat(Category.IT))
        {
            stats.increaseStat(Category.IT);
        }
        else
        {
            ITdone = true;
        }

        if (stats.Stat(Category.IS) < statsCopy.Stat(Category.IS))
        {
            stats.increaseStat(Category.IS);
        }
        else
        {
            ISdone = true;
        }

        if (stats.Stat(Category.EMC) < statsCopy.Stat(Category.EMC))
        {
            stats.increaseStat(Category.EMC);
        }
        else
        {
            EMCdone = true;
        }

        if (stats.Stat(Category.DS) < statsCopy.Stat(Category.DS))
        {
            stats.increaseStat(Category.DS);
        }
        else
        {
            DSdone = true;
        }

        yield return new WaitForSeconds(animationSpeed);

        /*Debug.Log("running");
        Debug.Log(CSdone + "" + ITdone + "" + ISdone + "" + EMCdone + "" + DSdone);*/

        UpdateStatsVisual();

        if(CSdone&&ITdone&&ISdone&&EMCdone&&DSdone)
        {
            /*Debug.Log("i die");*/

            StopAllCoroutines();
        }
        else
        {
            /*Debug.Log("keep goin");*/

            StartCoroutine(GrowStats());
        }

    }


    public void UpdateStatsVisual()
    {
/*
        CSbar.localScale = new Vector3(1, stats.StatNormalized(Category.CS),1);
        ITbar.localScale = new Vector3(1, stats.StatNormalized(Category.IT), 1);
*/

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[6];
        Vector2[] uv = new Vector2[6];
        int[] tri = new int[3 * 5];

        CSVertex = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * radarChartSize * stats.StatNormalized(Category.CS);
        int CSVertexIndex = 1;

        ITVertex = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * radarChartSize * stats.StatNormalized(Category.IT);
        int ITVertexIndex = 2;

        ISVertex = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * radarChartSize * stats.StatNormalized(Category.IS);
        int ISVertexIndex = 3;

        EMCVertex = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * stats.StatNormalized(Category.EMC);
        int EMCVertexIndex = 4;

        DSVertex = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * stats.StatNormalized(Category.DS);
        int DSVertexIndex = 5;

        vertices[0] = Vector3.zero;
        vertices[CSVertexIndex] = CSVertex;
        vertices[ITVertexIndex] = ITVertex;
        vertices[ISVertexIndex] = ISVertex;
        vertices[EMCVertexIndex] = EMCVertex;
        vertices[DSVertexIndex] = DSVertex;


        tri[0] = 0;
        tri[1] = CSVertexIndex;
        tri[2] = ITVertexIndex;

        tri[3] = 0;
        tri[4] = ITVertexIndex;
        tri[5] = ISVertexIndex;

        tri[6] = 0;
        tri[7] = ISVertexIndex;
        tri[8] = EMCVertexIndex;

        tri[9] = 0;
        tri[10] = EMCVertexIndex;
        tri[11] = DSVertexIndex;

        tri[12] = 0;
        tri[13] = DSVertexIndex;
        tri[14] = CSVertexIndex;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = tri;

        radarMeshCanvasRenderer.SetMesh(mesh); 
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, null);
    }
}
