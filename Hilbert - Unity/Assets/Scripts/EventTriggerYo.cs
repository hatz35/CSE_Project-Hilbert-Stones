using UnityEngine;
using UnityEngine.EventSystems;
public class EventTriggerYo : EventTrigger
{
    private MovementManager MM;
    private ToolBox TB;
    AudioSource audioSource;
    public AudioClip pressStone;
    public override void OnPointerClick(PointerEventData data)
    {
        GameObject GM = GameObject.FindGameObjectWithTag("Manager");
        MM = GM.GetComponent<MovementManager>();
        TB = GM.GetComponent<ToolBox>();
        if (!this.gameObject.GetComponent<Stone>().xBlocked)
        {
            TB.DisplayStoneData(this.gameObject);
            MM.SummonMove(this.gameObject);

        }

        /* Why this ain't working?
        GameObject SM = GameObject.FindGameObjectWithTag("Music");
        audioSource = SM.GetComponent<AudioSource>();
        audioSource.PlayOneShot(pressStone);
        */
    }


}
