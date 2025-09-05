using Mirror;
using UnityEngine;
public class PlayerMove : NetworkBehaviour {


    private void Update() {
        if (!isLocalPlayer) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.Translate(movement * Time.deltaTime * 0.75f);

    }
}
