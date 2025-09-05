using Mirror;
using UnityEngine;
public class PlayerMove : NetworkBehaviour {


    void Start() {

    }

    private void Update() {
        if (!isLocalPlayer) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Time.deltaTime * 0.75f);

    }
}
