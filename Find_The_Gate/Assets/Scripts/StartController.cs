using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public void ChangeGameState()
    {
        GameManager.instance.whatState = GameManager.GameState.game;
    }
}
