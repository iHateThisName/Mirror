using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour {

    PlayerElement playerElement;

    private void OnCollisionEnter2D(Collision2D collision) {

        PlayerElement collidedElement = collision.gameObject.GetComponentInParent<PlayerElement>();

        if (playerElement.element == ElementType.Fire && collidedElement.element == ElementType.Water) {
            GameManager.Instance.KillYourself(this.transform.parent.gameObject, playerElement.element);

        } else if (playerElement.element == ElementType.Water && collidedElement.element == ElementType.Grass) {
            GameManager.Instance.KillYourself(this.transform.parent.gameObject, playerElement.element);

        } else if (playerElement.element == ElementType.Grass && collidedElement.element == ElementType.Fire) {
            GameManager.Instance.KillYourself(this.transform.parent.gameObject, playerElement.element);
        }
    }
}
