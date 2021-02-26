using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button newgame, howtoplay, bestplayers, exit, _return, clear;
    public Image gamename;
    public Text authors, info, players;

    public void NewGame() {
        try {
            Steering steering = GameObject.Find("Head").GetComponent<Steering>();
            PlayerUI playerui = GameObject.Find("GameMaster").GetComponent<PlayerUI>();

            if (playerui.p_total > PlayerPrefs.GetInt("P0_1")) {
                PlayerPrefs.SetInt("P0_0", steering.n_tail);
                PlayerPrefs.SetInt("P0_1", playerui.p_total);
                PlayerPrefs.SetString("P0_2", playerui.FormatTime(playerui.actualtime));
            }
            else if (playerui.p_total > PlayerPrefs.GetInt("P1_1")) {
                PlayerPrefs.SetInt("P1_0", steering.n_tail);
                PlayerPrefs.SetInt("P1_1", playerui.p_total);
                PlayerPrefs.SetString("P1_2", playerui.FormatTime(playerui.actualtime));
            }
            else if (playerui.p_total > PlayerPrefs.GetInt("P2_1")) {
                PlayerPrefs.SetInt("P2_0", steering.n_tail);
                PlayerPrefs.SetInt("P2_1", playerui.p_total);
                PlayerPrefs.SetString("P2_2", playerui.FormatTime(playerui.actualtime));
            }
            else if (playerui.p_total > PlayerPrefs.GetInt("P3_1")) {
                PlayerPrefs.SetInt("P3_0", steering.n_tail);
                PlayerPrefs.SetInt("P3_1", playerui.p_total);
                PlayerPrefs.SetString("P3_2", playerui.FormatTime(playerui.actualtime));
            }
            else if (playerui.p_total > PlayerPrefs.GetInt("P4_1")) {
                PlayerPrefs.SetInt("P4_0", steering.n_tail);
                PlayerPrefs.SetInt("P4_1", playerui.p_total);
                PlayerPrefs.SetString("P4_2", playerui.FormatTime(playerui.actualtime));
            }
        }
        catch { }
        SceneManager.LoadScene("Scene");
    }
    public void Menu() {
        Steering steering = GameObject.Find("Head").GetComponent<Steering>();
        PlayerUI playerui = GameObject.Find("GameMaster").GetComponent<PlayerUI>();
        SceneManager.LoadScene("MainMenu");

        if (playerui.p_total > PlayerPrefs.GetInt("P0_1")) {
            PlayerPrefs.SetInt("P0_0", steering.n_tail);
            PlayerPrefs.SetInt("P0_1", playerui.p_total);
            PlayerPrefs.SetString("P0_2", playerui.FormatTime(playerui.actualtime));
        }
        else if (playerui.p_total > PlayerPrefs.GetInt("P1_1")) {
            PlayerPrefs.SetInt("P1_0", steering.n_tail);
            PlayerPrefs.SetInt("P1_1", playerui.p_total);
            PlayerPrefs.SetString("P1_2", playerui.FormatTime(playerui.actualtime));
        }
        else if (playerui.p_total > PlayerPrefs.GetInt("P2_1")) {
            PlayerPrefs.SetInt("P2_0", steering.n_tail);
            PlayerPrefs.SetInt("P2_1", playerui.p_total);
            PlayerPrefs.SetString("P2_2", playerui.FormatTime(playerui.actualtime));
        }
        else if (playerui.p_total > PlayerPrefs.GetInt("P3_1")) {
            PlayerPrefs.SetInt("P3_0", steering.n_tail);
            PlayerPrefs.SetInt("P3_1", playerui.p_total);
            PlayerPrefs.SetString("P3_2", playerui.FormatTime(playerui.actualtime));
        }
        else if (playerui.p_total > PlayerPrefs.GetInt("P4_1")) {
            PlayerPrefs.SetInt("P4_0", steering.n_tail);
            PlayerPrefs.SetInt("P4_1", playerui.p_total);
            PlayerPrefs.SetString("P4_2", playerui.FormatTime(playerui.actualtime));
        }
    }
    public void Exit() {
        Application.Quit();
    }
    public void Clear() {
        PlayerPrefs.DeleteAll();
        Return();
    }
    public void Info() {
        newgame.gameObject.SetActive(false);
        howtoplay.gameObject.SetActive(false);
        bestplayers.gameObject.SetActive(false);
        gamename.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);

        _return.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
    }
    public void Best() {
        newgame.gameObject.SetActive(false);
        howtoplay.gameObject.SetActive(false);
        bestplayers.gameObject.SetActive(false);
        gamename.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);

        _return.gameObject.SetActive(true);
        players.gameObject.SetActive(true);
        clear.gameObject.SetActive(true);

        string p = "";
        if (PlayerPrefs.HasKey("P0_1")) p = p + "1st. place:\t\t" + PlayerPrefs.GetInt("P0_0") + "\t\t" + PlayerPrefs.GetInt("P0_1") + "\t\t" + PlayerPrefs.GetString("P0_2") + "\n";
        if (PlayerPrefs.HasKey("P1_1")) p = p + "2nd. place:\t\t" + PlayerPrefs.GetInt("P1_0") + "\t\t" + PlayerPrefs.GetInt("P1_1") + "\t\t" + PlayerPrefs.GetString("P1_2") + "\n";
        if (PlayerPrefs.HasKey("P2_1")) p = p + "3rd. place:\t\t" + PlayerPrefs.GetInt("P2_0") + "\t\t" + PlayerPrefs.GetInt("P2_1") + "\t\t" + PlayerPrefs.GetString("P2_2") + "\n";
        if (PlayerPrefs.HasKey("P3_1")) p = p + "4th. place:\t\t" + PlayerPrefs.GetInt("P3_0") + "\t\t" + PlayerPrefs.GetInt("P3_1") + "\t\t" + PlayerPrefs.GetString("P3_2") + "\n";
        if (PlayerPrefs.HasKey("P4_1")) p = p + "5th. place:\t\t" + PlayerPrefs.GetInt("P4_0") + "\t\t" + PlayerPrefs.GetInt("P4_1") + "\t\t" + PlayerPrefs.GetString("P4_2") + "\n";
        players.text = p;
    }
    public void Return() {
        _return.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        players.gameObject.SetActive(false);
        clear.gameObject.SetActive(false);

        newgame.gameObject.SetActive(true);
        howtoplay.gameObject.SetActive(true);
        bestplayers.gameObject.SetActive(true);
        gamename.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
    }
}
