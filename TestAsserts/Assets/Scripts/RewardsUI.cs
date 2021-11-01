using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class RewardsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI itensText;

    [Header("TEST")]
    [SerializeField] private RewardData testReward;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowRewards(testReward);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ShowRewards(null);
        }
    }

    public void ShowRewards(RewardData rewards)
    {
        Assert.IsNotNull(rewards, "Nao devemos mostrar o Popup de rewards se a Quest nao tiver rewards");
        if (rewards != null)
        {
            coinsText.text = $"Coins: ${rewards.Coins}";
            itensText.text = $"Items: \n{string.Join("\n", rewards.Items)}";
        }

    }
}










