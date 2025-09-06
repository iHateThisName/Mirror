using Mirror;
using UnityEngine;
public class PlayerMove : NetworkBehaviour {
    private void Update() {
        if (!isLocalPlayer) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        Vector3 newPosition = transform.position + movement * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -9f, 9f);
        newPosition.y = Mathf.Clamp(newPosition.y, -5f, 5f);
        this.transform.position = newPosition;
    }
}
