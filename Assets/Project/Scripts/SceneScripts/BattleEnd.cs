using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleEnd : MonoBehaviour
{
    [SerializeField]
    GameObject selectedCard;
    [SerializeField]
    GameObject rewardPanel;

    public GameObject cardDisplayPrefab;

    private void Start()
    {
        this.SetReward();
    }

    public void SetReward()
    {
        for(int i = 0; i < GameManager.Instance.numBattleEndReward; i++)
        {
            Card tmpCard = DeckManager.Instance.GetRandomCardFromAllCardList();
            GameObject tmp = Instantiate(cardDisplayPrefab,
                                          rewardPanel.transform);
            tmp.GetComponent<CardDisplay>().BindCard(tmpCard);
            SetOnClickMask(tmp);
        }
    }

    public void SetOnClickMask(GameObject tmp)
    {
        tmp.AddComponent<Button>();
        tmp.GetComponent<Button>().onClick.AddListener(()=>OnClickReward(tmp));
    }

    public void OnClickReward(GameObject tmp)
    {
        if(selectedCard != null)
        {
            selectedCard.GetComponent<CardDisplay>().SetHighlight(false);
        }
        selectedCard = tmp;
        selectedCard.GetComponent<CardDisplay>().SetHighlight(true);
    }

    public void GetReward()
    {
        Card reward = selectedCard.GetComponent<CardDisplay>().cardData;
        DeckManager.Instance.InsertCardToPlayerCardList(reward);

        SceneManager.LoadScene("MapUI");
        //SceneManager.LoadScene(PlayerPrefs.GetString("MapUI"));
        //SceneManager.LoadScene(SceneManager.GetActiveScene());
    }
}
