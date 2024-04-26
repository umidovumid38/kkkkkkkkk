using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public int MaxCoinCount;
    public int CoinCount;
    public Text cointText;
    public GameObject SceneWIn;
    private void Start()
    {
        SceneWIn.SetActive(false);
        MaxCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        REfreshUI();
    }
    public void AddCoin()
    {
        CoinCount++;
        REfreshUI();
        if (CoinCount >= MaxCoinCount)
        {
            SceneWIn.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            int sceneID = SceneManager.GetActiveScene().buildIndex;
            Levelcomplite.CourLevelcomplite[sceneID] = true;
            Debug.Log("Win");

        }
    }
    private void REfreshUI() 
    {
        if (cointText )
        {
            cointText.text = "Coin: " + CoinCount + "/" + MaxCoinCount;
        }
    }
}
