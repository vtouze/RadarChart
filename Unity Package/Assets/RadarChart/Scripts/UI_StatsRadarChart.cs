using UnityEngine;

public class UI_StatsRadarChart : MonoBehaviour {

    [SerializeField] private Material radarMaterial;
    [SerializeField] private Texture2D radarTexture2D;

    private Stats stats;
    private CanvasRenderer radarMeshCanvasRenderer;

    private void Awake() {
        radarMeshCanvasRenderer = transform.Find("radarMesh").GetComponent<CanvasRenderer>();
    }

    public void SetStats(Stats stats) {
        this.stats = stats;
        stats.OnStatsChanged += Stats_OnStatsChanged;
        UpdateStatsVisual();
    }

    private void Stats_OnStatsChanged(object sender, System.EventArgs e) {
        UpdateStatsVisual();
    }

    private void UpdateStatsVisual() {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[10];
        Vector2[] uv = new Vector2[10];
        int[] triangles = new int[3 * 9];

        float angleIncrement = 360f / 9;
        float radarChartSize = 145f;

        // Existing stats vertices
        Vector3 attackVertex = Quaternion.Euler(0, 0, -angleIncrement * 0) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Attack);
        int attackVertexIndex = 1;
        Vector3 defenceVertex = Quaternion.Euler(0, 0, -angleIncrement * 1) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Defence);
        int defenceVertexIndex = 2;
        Vector3 speedVertex = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Speed);
        int speedVertexIndex = 3;
        Vector3 manaVertex = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Mana);
        int manaVertexIndex = 4;
        Vector3 healthVertex = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Health);
        int healthVertexIndex = 5;

        // New stats vertices
        Vector3 powerVertex = Quaternion.Euler(0, 0, -angleIncrement * 5) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Power);
        int powerVertexIndex = 6;
        Vector3 agilityVertex = Quaternion.Euler(0, 0, -angleIncrement * 6) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Agility);
        int agilityVertexIndex = 7;
        Vector3 luckVertex = Quaternion.Euler(0, 0, -angleIncrement * 7) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Luck);
        int luckVertexIndex = 8;
        Vector3 intelligenceVertex = Quaternion.Euler(0, 0, -angleIncrement * 8) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Intelligence);
        int intelligenceVertexIndex = 9;

        // Assign vertices
        vertices[0] = Vector3.zero;
        vertices[attackVertexIndex]  = attackVertex;
        vertices[defenceVertexIndex] = defenceVertex;
        vertices[speedVertexIndex]   = speedVertex;
        vertices[manaVertexIndex]    = manaVertex;
        vertices[healthVertexIndex]  = healthVertex;
        vertices[powerVertexIndex]   = powerVertex;
        vertices[agilityVertexIndex] = agilityVertex;
        vertices[luckVertexIndex]    = luckVertex;
        vertices[intelligenceVertexIndex] = intelligenceVertex;

        // UV coordinates
        uv[0]                   = Vector2.zero;
        uv[attackVertexIndex]   = Vector2.one;
        uv[defenceVertexIndex]  = Vector2.one;
        uv[speedVertexIndex]    = Vector2.one;
        uv[manaVertexIndex]     = Vector2.one;
        uv[healthVertexIndex]   = Vector2.one;
        uv[powerVertexIndex]    = Vector2.one;
        uv[agilityVertexIndex]  = Vector2.one;
        uv[luckVertexIndex]     = Vector2.one;
        uv[intelligenceVertexIndex] = Vector2.one;

        // Triangles
        triangles[0] = 0;
        triangles[1] = attackVertexIndex;
        triangles[2] = defenceVertexIndex;

        triangles[3] = 0;
        triangles[4] = defenceVertexIndex;
        triangles[5] = speedVertexIndex;

        triangles[6] = 0;
        triangles[7] = speedVertexIndex;
        triangles[8] = manaVertexIndex;

        triangles[9]  = 0;
        triangles[10] = manaVertexIndex;
        triangles[11] = healthVertexIndex;

        triangles[12] = 0;
        triangles[13] = healthVertexIndex;
        triangles[14] = powerVertexIndex;

        // New triangles for the new stats
        triangles[15] = 0;
        triangles[16] = powerVertexIndex;
        triangles[17] = agilityVertexIndex;

        triangles[18] = 0;
        triangles[19] = agilityVertexIndex;
        triangles[20] = luckVertexIndex;

        triangles[21] = 0;
        triangles[22] = luckVertexIndex;
        triangles[23] = intelligenceVertexIndex;

        triangles[24] = 0;
        triangles[25] = intelligenceVertexIndex;
        triangles[26] = attackVertexIndex;

        /*triangles[27] = 0;
        triangles[28] = speedVertexIndex;
        triangles[29] = luckVertexIndex;

        triangles[30] = 0;
        triangles[31] = luckVertexIndex;
        triangles[32] = manaVertexIndex;

        triangles[33] = 0;
        triangles[34] = manaVertexIndex;
        triangles[35] = intelligenceVertexIndex;

        triangles[36] = 0;
        triangles[37] = intelligenceVertexIndex;
        triangles[38] = healthVertexIndex;*/

        // Apply the mesh
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, radarTexture2D);
    }
}