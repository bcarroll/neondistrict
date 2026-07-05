using UnityEngine;

public class CharacterPresetManager : MonoBehaviour {
    public GameObject playerPrefab; // Assign in inspector
    
    public void SpawnHuman() => InstantiatePlayer("Human");
    public void SpawnCanine() => InstantiatePlayer("Canine");
    public void SpawnAvian() => InstantiatePlayer("Avian");

    void InstantiatePlayer(string type) {
        Destroy(FindAnyObjectByType<PlayerController>().gameObject);
        
        var go = new GameObject(type + "_Fallback");
        go.tag = "Player";
        var mf = go.AddComponent<MeshFilter>();
        var mr = go.AddComponent<MeshRenderer>();
        var bc = go.AddComponent<BoxCollider>();
        var pc = go.AddComponent<PlayerController>();

        Mesh mesh = type switch {
            "Canine" => CreateCapsule(0.5f, 1f),
            "Avian" => CreateCapsule(0.3f, 0.6f),
            _ => CreateBox(1f, 2f, 0.5f)
        };
        
        mf.mesh = mesh;
        mr.material = new Material(Shader.Find("Standard")) { color = type == "Canine" ? Color.gray :
                                                                      type == "Avian" ? Color.green : Color.blue };

        Instantiate(go, Vector3.zero, Quaternion.identity);
    }

    static Mesh CreateBox(float w, float h, float d) {
        var m = new Mesh();
        var v = new[] {
            new Vector3(-w/2, 0, -d/2), new(w/2, 0, -d/2), new(w/2, h, -d/2), new(-w/2, h, -d/2),
            new(-w/2, 0, d/2), new(w/2, 0, d/2), new(w/2, h, d/2), new(-w/2, h, d/2)
        };
        int[] t = {0,1,2,0,2,3, 4,5,6,4,6,7, 0,4,7,0,7,3, 1,5,6,1,6,2, 3,2,6,3,6,7, 4,0,1,4,1,5};
        m.vertices = v; m.triangles = t; return m;
    }
    
    static Mesh CreateCapsule(float r, float h) => GameObject.CreatePrimitive(PrimitiveType.Capsule).GetComponent<MeshFilter>().mesh;
}