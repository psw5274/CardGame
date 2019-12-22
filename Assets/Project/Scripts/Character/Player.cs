using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Player로 지었지만 thief, warrior 등으로 바뀔 예정
public class Player : Character
{

    public Sprite GetPlayerStandingImage()
    {
        return characterData.playerStandingImage;
    }

    public override void BindCharacter(CharacterData data)
    {
        base.BindCharacter(data);

        DeckManager.Instance.SetPlayerCardList(data.playerDefaultDeck);
    }
}
