using Mirror;
public class GameManager : NetworkBehaviour {

    public static GameManager Instance;

    [SyncVar] private int fireCount = 0;
    [SyncVar] private int waterCount = 0;
    [SyncVar] private int grassCount = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public ElementType AssignElement() {
        if (fireCount <= waterCount && fireCount <= grassCount) {
            fireCount++;
            return ElementType.Fire;
        } else if (waterCount <= fireCount && waterCount <= grassCount) {
            waterCount++;
            return ElementType.Water;
        } else {
            grassCount++;
            return ElementType.Grass;
        }
    }

    public void RemoveElement(ElementType type) {
        switch (type) {
            case ElementType.Fire:
                fireCount--;
                break;
            case ElementType.Water:
                waterCount--;
                break;
            case ElementType.Grass:
                grassCount--;
                break;
        }
    }
}
