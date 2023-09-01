using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : BaseButton
{
    public override void OnButtonClick(GameObject gameObject)
    {
        gameObject.SetActive(false);
        GameStateHandler.Instance.SetState(GameState.Gameplay);
        SceneManager.LoadScene(1);
    }
}
