using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : ViewModel
{
    public override GameObject SetScreen(GameObject screen, Transform parent)
    {
        GameObject spawnedScreen = Instantiate(screen, parent);
        return spawnedScreen;
    }
}

public abstract class ViewModel : MonoBehaviour
{
    public abstract GameObject SetScreen(GameObject screen, Transform parent);
}

