using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public static int coinCount;
    private Text _coinWallet;

    void Start()
    {
        _coinWallet = GetComponent<Text>();
        coinCount = 0;
    }

    void Update()
    {
		_coinWallet.text = "Coin count: " + coinCount;
	}
}
