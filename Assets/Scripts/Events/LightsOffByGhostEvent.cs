using UnityEngine;

public class LightsOffByGhostEvent : MonoBehaviour
{
    [SerializeField] private int keysRequiredToTrigger;
    [SerializeField] private SoundType soundToPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerView>() != null && GameService.Instance.GetPlayerController().KeysEquipped == keysRequiredToTrigger)
        {
            EventService.Instance.LightsOffByGhostEvent.InvokeEvent();
            GameService.Instance.GetSoundView().PlaySoundEffects(soundToPlay);
            Debug.Log(GameService.Instance.GetPlayerController().PlayerState);
            GetComponent<Collider>().enabled = false;
        }
    }
}