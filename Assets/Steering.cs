using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Steering : MonoBehaviour {
    public static List<GameObject> T = new List<GameObject>();

	public GameObject tail;
    public Camera minimap;
    public Transform aim;
    PlayerUI playerui;

    public int n_tail, point_tail;
    public float cameraspeed;
	public bool alive, walls, steering;

    void Start() {
        Color32 color = new Color32(58, 37, 79, 255);
        GetComponent<Renderer>().material.SetColor("_Color", color);
        tail.GetComponent<Renderer>().material.SetColor("_Color", color);
        playerui = GameObject.Find("GameMaster").GetComponent<PlayerUI>();

        playerui.pause = false;
        T.Clear();
        T.Add(tail);
        for (int i = 1; i < n_tail; i++)
            T.Add(Instantiate(tail, new Vector3(-0.2f - 0.2f * i, 0, 0), Quaternion.identity));
    }
    void Update() {
        Vector3 v3 = new Vector3(Input.GetAxis("Rotate"), Input.GetAxis("Mouse X") + Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") + Input.GetAxis("Mouse Y"));
        if (steering && !playerui.pause) {
            transform.Rotate(v3 * cameraspeed * Time.deltaTime);
        }
    }
    void FixedUpdate() {
        if (alive && !playerui.pause) {
            for (int i = n_tail - 1; i > 0; i--) {
                Transform t_tail = T[i].GetComponent<Transform>();
                Transform p_tail = T[i - 1].GetComponent<Transform>();

                if (i >= 10) {
                    float dx = t_tail.position.x - aim.position.x;
                    float dy = t_tail.position.y - aim.position.y;
                    float dz = t_tail.position.z - aim.position.z;
                    float dd = dx * dx + dy * dy + dz * dz;
                    if (dd <= 1f) {
                        alive = false;
                        steering = false;
                        Debug.Log("Eated itself");
                        playerui.death = 1;
                    }
                }
                t_tail.SetPositionAndRotation(p_tail.position, p_tail.rotation);
            }
            T[0].GetComponent<Transform>().SetPositionAndRotation(transform.position, transform.rotation);
            transform.SetPositionAndRotation(aim.position, aim.rotation);

            if ((transform.position.x > 24 || transform.position.x < -24 ||
            transform.position.y > 24 || transform.position.y < -24 ||
            transform.position.z > 24 || transform.position.z < -24) && walls)
            {
                alive = false;
                steering = false;
                Debug.Log("Crossed the line");
                playerui.death = 0;
            }
        }
    }
	public void AddTail() {
        for (int i = 0; i < point_tail; i++) {
            Transform p_tail = T.Last().GetComponent<Transform>();
            T.Add(Instantiate(tail, p_tail.position, p_tail.rotation));
            n_tail++;
        }
	}
}