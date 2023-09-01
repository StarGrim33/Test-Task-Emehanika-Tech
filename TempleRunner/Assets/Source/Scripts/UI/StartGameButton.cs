using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : BaseButton
{
    public override void OnButtonClick(GameObject gameObject)
    {
        SceneManager.LoadScene(1);
    }
}
