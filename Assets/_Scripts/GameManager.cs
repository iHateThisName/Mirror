using Mirror;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : NetworkManager {

    public static GameManager Instance;

    private int fireCount = 0;
    private int waterCount = 0;
    private int grassCount = 0;

    [SerializeField] private List<GameObject> graveyard = new List<GameObject>();

    public Transform FireSpawnPoint, WaterSpawnPoint, GrassSpawnPoint;

    public override void Awake() {
        base.Awake();
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

    public void KillYourself(GameObject player, ElementType element) {
        if (player == null) return;

        for (int i = 0; i < player.transform.childCount; i++) {
            GameObject child = player.transform.GetChild(i).gameObject;
            this.graveyard.Add(child);
            child.SetActive(false);
        }
        if (this.graveyard.Count == 4) {
            RespawnAll();
        }
    }

    private void RespawnAll() {
        this.graveyard.ForEach(go => {
            if (go == null) {
                this.graveyard.Remove(go);

            } else {
                this.graveyard.Remove(go);
                go.SetActive(true);
                ElementType element = go.transform.parent.GetComponent<PlayerElement>().element;
                go.transform.position = GetSpawnPoint(element).position;
            }
        });
    }

    public Transform GetSpawnPoint(ElementType element) {
        switch (element) {
            case ElementType.Fire:
                return FireSpawnPoint;

            case ElementType.Water:
                return WaterSpawnPoint;

            case ElementType.Grass:
                return GrassSpawnPoint;

            default:
                return FireSpawnPoint;
        }
    }
}
