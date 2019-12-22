using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField]
    List<CharacterData> SelectableCharacters;
    [SerializeField]
    Image characterImage;
    [SerializeField]
    Text characterDescription;
    [SerializeField]
    Image lockMessage;
    public int currentSelectionIdx = 0;

    private void Awake()
    {
        characterImage = GameObject.Find("CharacterImage").GetComponent<Image>();
    }

    private void Start()
    {
        SetCharacterImage();
    }

    public void SetNextCharacter()
    {
        currentSelectionIdx++;
        currentSelectionIdx %= SelectableCharacters.Count;

        SetCharacterImage();
    }

    public void SetPrevCharacter()
    {
        currentSelectionIdx--;
        currentSelectionIdx += SelectableCharacters.Count;
        currentSelectionIdx %= SelectableCharacters.Count;

        SetCharacterImage();
    }

    public void SelectCharacter()
    {
        if (SelectableCharacters[currentSelectionIdx].isUnlock)
        {
            GameManager.Instance.SetPlayerCharacter(SelectableCharacters[currentSelectionIdx]);

            SceneManager.LoadScene("MapUI");
        }
    }
    private void SetCharacterImage()
    {
        if(SelectableCharacters[currentSelectionIdx].playerStandingImage != null)
        characterImage.sprite =
            SelectableCharacters[currentSelectionIdx].playerStandingImage;
        characterDescription.text = SelectableCharacters[currentSelectionIdx].characterName;
        if (!SelectableCharacters[currentSelectionIdx].isUnlock)
        {
            lockMessage.gameObject.SetActive(true);
        }
        else
        {
            lockMessage.gameObject.SetActive(false);
        }
    }
}
