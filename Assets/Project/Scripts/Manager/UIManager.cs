using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Manager<UIManager>
{
    public GameObject handZone;
    public GameObject hpBarPrefab;
    public GameObject barrierBarPrefab;

    public Image costUI;
    private Text costText;

    public Button newTurnButton;
    public Button endBattleButton;

    [SerializeField]
    private Text StoryDialog;
    [SerializeField]
    private Text SystemDialog;

    private void Awake()
    {
        if (costUI == null)
        {
            costUI = GameObject.Find("CostImage").GetComponent<Image>();
        }
        costText = costUI.transform.Find("Text").GetComponent<Text>();

    }

    public void OnHitUI(GameObject target)
    {

    }

    public void SetCostText(int remain, int max)
    {
        costText.text = remain + "/" + max;
    }

    public void SetTurnButton(Team turn)
    {
        if(turn == Team.Enemy)
        {
            newTurnButton.GetComponentInChildren<Text>().text = "상대 턴";
            newTurnButton.enabled = false;
        }
        else
        {
            newTurnButton.GetComponentInChildren<Text>().text = "다음 턴";
            newTurnButton.enabled = true;
        }
    }

    public void SetEndBattleButton(bool isWin)
    {
        newTurnButton.gameObject.SetActive(false);
        endBattleButton.gameObject.SetActive(true);

        endBattleButton.onClick.AddListener(delegate{ GameManager.Instance.EndBattle(isWin); });
    }

    public void SetSystemDialog(string text, float time = 2f)
    {
        SystemDialog.text = text;
        StartCoroutine(SystemDialogTTL(time));
    }

    //need fade in & fade out
    IEnumerator SystemDialogTTL(float time)
    {
        var Background = SystemDialog.transform.Find("Image").GetComponent<Image>();

        Background.enabled = true;
        SystemDialog.enabled = true;
        if (time != 0)
        {
            yield return new WaitForSeconds(time);
            SystemDialog.enabled = false;
            Background.enabled = false;
        }
    }
}
