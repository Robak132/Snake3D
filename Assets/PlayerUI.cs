using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
    public Text SnakeSize, Points, Timer, GameOver2;
    public Image PauseMenu, GameOver;
    public Button ExitMenu, ExitGame;
    public AudioSource soundtrack;
    Steering steering;

    public int p_sec, p_star, p_star_total, p_total, death;
    public float actualtime;
    float starttime, beginpause, pausetime;
    public bool pause;

    void OnLevelWasLoaded() {
        steering = GameObject.Find("Head").GetComponent<Steering>();
        starttime = 0;
        actualtime = 0;
        beginpause = 0;
        pausetime = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update() {
        if (steering.alive) {
            if (Input.GetButtonDown("GameMenu")) {
                if (pause) {
                    soundtrack.Play();
                    ExitMenu.gameObject.SetActive(false);
                    ExitGame.gameObject.SetActive(false);
                    PauseMenu.gameObject.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else {
                    soundtrack.Stop();
                    ExitMenu.gameObject.SetActive(true);
                    ExitGame.gameObject.SetActive(true);
                    PauseMenu.gameObject.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    beginpause = Time.timeSinceLevelLoad - starttime;
                }
                pause = !pause;
            }
            actualtime = Time.timeSinceLevelLoad - starttime - pausetime;
            if (pause) {
                pausetime = Time.timeSinceLevelLoad - beginpause;
            }
            p_total = (int)(actualtime) * p_sec + p_star_total;
            SnakeSize.text = "Snake Size:\n" + steering.n_tail;
            Points.text = "Points:\n" + p_total;
            Timer.text = "Time:\n" + FormatTime(actualtime);
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            soundtrack.Stop();

            steering.minimap.enabled = false;
            GameOver.gameObject.SetActive(true);
            ExitMenu.gameObject.SetActive(true);
            ExitGame.gameObject.SetActive(true);
            switch (death) {
                case 0:
                    GameOver2.text = "You hit the wall";
                    GameOver2.gameObject.SetActive(true);
                    break;
                case 1:
                    GameOver2.text = "You ate your own tail";
                    GameOver2.gameObject.SetActive(true);
                    break;
                case 2:
                    GameOver2.text = "You ate star";
                    GameOver2.gameObject.SetActive(true);
                    break;
            }
            SnakeSize.transform.SetPositionAndRotation(new Vector3(660, 540, 0), Quaternion.identity);
            Points.transform.SetPositionAndRotation(new Vector3(960, 540, 0), Quaternion.identity);
            Timer.transform.SetPositionAndRotation(new Vector3(1260, 540, 0), Quaternion.identity);
        }
    }
    public string FormatTime (float time) {
        if (time >= 600) {
            if (time % 60 < 10)
                return "" + (int)(time / 60) + ":0" + (int)(time % 60);
            else
                return "" + (int)(time / 60) + ":" + (int)(time % 60);
        }
        else {
            if (time % 60 < 10)
                return "0" + (int)(time / 60) + ":0" + (int)(time % 60);
            else
                return "0" + (int)(time / 60) + ":" + (int)(time % 60);
        }
    }
}