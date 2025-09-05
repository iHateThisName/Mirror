using Mirror;
using UnityEngine;

public class PlayerElement : NetworkBehaviour {

    [SyncVar(hook = nameof(OnElementChanged))]
    public ElementType element;

    [SerializeField] private Renderer ren;
    void Start() {

        if (isServer) { // true of the object is on the server
            this.element = GameManager.Instance.AssignElement();
        }
    }

    void Update() {

    }

    public override void OnStopServer() {
        base.OnStopServer();
        GameManager.Instance.RemoveElement(element);
    }

    // Called on clients when SyncVar changes
    private void OnElementChanged(ElementType oldElement, ElementType newElement) {
        Color c = Color.white;
        switch (newElement) {
            case ElementType.Fire: c = Color.red; break;
            case ElementType.Water: c = Color.blue; break;
            case ElementType.Grass: c = Color.green; break;
        }
        this.ren.material.color = c;
    }
}
