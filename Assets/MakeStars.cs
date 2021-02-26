using UnityEngine;
using System.Collections.Generic;

public class MakeStars : MonoBehaviour {
    public static List<GameObject> O = new List<GameObject>();
    public static List<GameObject> C = new List<GameObject>();
    public GameObject Obj_1, Obj_2, Obj_3, Obj_4, Collider;
    public AudioSource eat;
    PlayerUI playerui;
    Transform head;
    Steering steering;

    public int N_obj, N_colliders, Min_n_obj;
    public float X_max, Y_max, Z_max;

    void Start() {
        playerui = GameObject.Find("GameMaster").GetComponent<PlayerUI>();
        head = GameObject.Find("Head").GetComponent<Transform>();
        steering = GameObject.Find("Head").GetComponent<Steering>();

        for (int i = 0; i < N_obj; i++)
			CreateObj();
        for (int i = 0; i < N_colliders; i++)
            CreateCollider();
    }
	void Update() {
		foreach (GameObject obj in O) {
			if (obj) {
                Transform fruit_pos = obj.GetComponent<Transform>();

                float dx = fruit_pos.position.x - head.position.x;
				float dy = fruit_pos.position.y - head.position.y;
				float dz = fruit_pos.position.z - head.position.z;
				float dd = dx * dx + dy * dy + dz * dz;
				if (dd <= 0.9f) {
					N_obj--;
					Destroy (obj);
					playerui.p_star_total += playerui.p_star;
					GameObject.Find ("Head").GetComponent<Steering> ().AddTail ();
                    eat.Play();
                }
			}
		}
        foreach (GameObject col in C) {
            if (col) {
                Transform col_pos = col.GetComponent<Transform>();

                float dx = col_pos.position.x - head.position.x;
                float dy = col_pos.position.y - head.position.y;
                float dz = col_pos.position.z - head.position.z;
                float dd = dx * dx + dy * dy + dz * dz;
                if (dd <= 1.5f) {
                    steering.alive = false;
                    steering.steering = false;
                    Debug.Log("Eated star");
                    playerui.death = 2;
                }
            }
        }
        if (N_obj < Min_n_obj) {
			N_obj++;
			CreateObj();
		}
	}
	void CreateObj() {
		float x = Random.Range(-X_max, X_max);
		float y = Random.Range(-X_max, Y_max);
		float z = Random.Range(-X_max, Z_max);
		Vector3 v = new Vector3 (x, y, z);
		switch (Random.Range(1,4)) {
			case 1: O.Add(Instantiate(Obj_1, v, Random.rotation));break;
			case 2: O.Add(Instantiate(Obj_2, v, Random.rotation));break;
			case 3: O.Add(Instantiate(Obj_3, v, Random.rotation));break;
			case 4: O.Add(Instantiate(Obj_4, v, Random.rotation));break;
		}
	}
    void CreateCollider() {
        float x = Random.Range(-X_max, X_max);
        float y = Random.Range(-X_max, Y_max);
        float z = Random.Range(-X_max, Z_max);
        Vector3 v = new Vector3(x, y, z);
        C.Add(Instantiate(Collider, v, Random.rotation));
    }
}