using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DOTween.KillAll();
    }

}
