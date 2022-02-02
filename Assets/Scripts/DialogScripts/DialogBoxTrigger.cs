using UnityEngine;

public class DialogBoxTrigger : MonoBehaviour
{
   
    [SerializeField] GameObject dialogBox;
    [SerializeField] Animator anim;
    [SerializeField] public string dialog;
    private bool interactKeyPressed;
    private bool inInteractRange = false;

    private void Start()
    {
        interactKeyPressed = false;
    }

    private void Update()
    {
        // update if interaction key is being pressed
        interactKeyPressed = Input.GetKey(Constants.INTERACTION_KEY);

        // the player has pressed the interaction key, there is not a current pop up running, and the player is within the dialog box trigger
        if (interactKeyPressed && !Dialog.isPopUpActive && inInteractRange)
        {
            Dialog Dialog = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Dialog>();
            Dialog.Open(dialog, dialogBox, anim);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        inInteractRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        inInteractRange = false;
    }
}
