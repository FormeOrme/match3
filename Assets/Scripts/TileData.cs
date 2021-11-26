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
        r = Random.Range (0.0f, 1.0f);
        render = Instantiate (render, new Vector3 (0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
        delta += 0.001F;
        if (delta > 1) delta = 1;

        float ly = data.EOB(Mathf.Lerp(yF, y, delta));

        render.transform.position = new Vector3 (x * (1 + data.padding), ly * (1 + data.padding), 0);
    }
}