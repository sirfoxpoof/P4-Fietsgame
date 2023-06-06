using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BetterDingDong : MonoBehaviour
{
    // Usage:
    // 1) Add to Player
    // 2) Add BetterDingDong -> PartyTime to PlayerInput FietsBel action

    public Transform[] dingThis;

    public void DongThis (InputAction.CallbackContext context) {
        if (context.performed) {
            StartCoroutine(DoTheDong());
        }
    }

    public IEnumerator DoTheDong () {

        for (int i = 0; i < 8; i++) {
            DeBabiDong();
            yield return new WaitForSeconds(.05f);
        }

        foreach (Transform ding in dingThis) {
            ding.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void DeBabiDong () {
        foreach (Transform ding in dingThis) {
            float deDiDong = Random.Range(0.25f, 1f);
            // Bami
            ding.localScale = new Vector3(deDiDong, deDiDong, deDiDong);
        }
    }
}
