using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCanvasInterface : MonoBehaviour
{
    [SerializeField] private GameObject background;
    private Canvas canvas;
    public Text UIText;
    private void Awake()
    {
        canvas = this.GetComponent<Canvas>();
    }

    public void Show(Camera camera,int scoreToRevive)
    {
        this.canvas.worldCamera = camera;
        this.background.SetActive(true);
        this.UIText.text = scoreToRevive.ToString();

    }
    public void Unshow()
    {
        this.background.SetActive(false);
    }
    public void DeadScoreUpdate(int scoreToRevive)
    {
        this.UIText.text = scoreToRevive.ToString();
    }
}
