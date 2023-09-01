using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuButton : BaseButton
{
    public override void OnButtonClick(GameObject gameObject = null)
    {
        SceneManager.LoadScene(0);
    }
}
