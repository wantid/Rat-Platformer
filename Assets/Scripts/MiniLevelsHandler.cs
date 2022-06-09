using UnityEngine;

public class MiniLevelsHandler : MonoBehaviour
{
    public Transform parent;

    [ContextMenu("New Level")]
    public void NewLevel()
    {
        if (IsReady())
            Instantiate(LinkToObjects.instance.miniLevels[Random.Range(0, LinkToObjects.instance.miniLevels.Length)], parent);
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
