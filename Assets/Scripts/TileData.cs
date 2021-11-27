using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour {

    public GameObject render;
    public GameOrchestratorData data;

    private float delta;

    private int id;
    public int x;
    public int y;
    public int yF;
    public float r;

    // Start is called before the first frame update
    void Start () {
        delta = 0;
        r = Random.Range (0.9f, 1.1f);
        render = Instantiate (render, new Vector3 (0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
        delta += Time.deltaTime;
        if (delta > 1) delta = 1;

        float ly = (Mathf.Lerp (yF, y, EasingTools.easeOutBounce (EasingTools.easePow (delta, r))));

        render.transform.position = new Vector3 (x * (data.L + data.padding * 2), ly * (data.L + data.padding * 2), 0);

        MeshRenderer renderer = render.GetComponent<MeshRenderer> ();
        renderer.material.color = data.colors[data.grid[x, y]];

    }
}