using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private int[] shapes = { 0, 1, 2, 3 };
    private int[] colours = { 0, 1, 2, 3 };
    private Color[] colo = { Color.red, Color.blue, Color.green, Color.yellow };
    private Material m_Material;

    public int shape;
    public int colour;

    private int index, index2;
    public GameObject spawner;

	// Use this for initialization
	void Start () {
        spawner = GameObject.Find("spawner");
        index = Random.Range(0, 3);
        index2 = Random.Range(0, 3);
        shape = shapes[index];
        colour = colours[index];
        m_Material = GetComponent<Renderer>().material;
    }

    IEnumerator wait()
    {
        Debug.Log(1234);
        yield return new WaitForSeconds(3);
    }

    // Update is called once per frame
    void Update () {
        m_Material.color = colo[colour];
    }

    void OnTriggerExit(Collider colli)
    {
        StartCoroutine(wait());
        index = Random.Range(0, 3);
        index2 = Random.Range(0, 3);
        shape = shapes[index];
        colour = colours[index];
        spawner.GetComponent<spawner>().spawn();

    }

}
