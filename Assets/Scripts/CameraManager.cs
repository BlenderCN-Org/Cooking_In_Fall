using UnityEngine;

public class CameraManager : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void GoGame()
    {
        anim.SetBool("GoMenu", false);
    }

    public void GoMenu()
    {
        anim.SetBool("GoMenu", true);
    }
}
