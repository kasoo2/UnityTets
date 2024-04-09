using UnityEngine;

public class WindowController : MonoBehaviour
{
    public GameObject CongratulationWindow;

    void Start()
    {
		CongratulationWindow.SetActive(false);
	}

    void Update()
    {
        if(CoinCollect.coinCount == 3)
        {
			CongratulationWindow.SetActive(true);
		}
    }

    public void LoadMenu()
    {
        Debug.Log("Меню открыто!");
    }
}
