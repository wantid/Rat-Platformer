using UnityEngine;

public class MiniLevelsHandler : MonoBehaviour
{
    public GameObject[] miniLevels;

    public Transform parent;

    [ContextMenu("New Level")]
    public void NewLevel()
    {
        if (IsReady())
            Instantiate(miniLevels[Random.Range(0, miniLevels.Length)], parent);
    }
    private bool IsReady()
    {
        foreach (Transform child in parent)
        {
            if (child.childCount == 0)
                Destroy(child.gameObject);
        }

        if (parent.childCount == 0)
            return true;

        return false;
    }
}
