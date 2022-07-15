using UnityEngine;

public class MiniLevelsHandler : MonoBehaviour
{
    public Transform parent;

    private float time;
    private float counter;

    private void Start()
    {
        counter = 28;
    }
    private void Update()
    {
        if (time <= 0)
        {
            counter++;
            time = Mathf.Clamp(8 - Mathf.Exp((counter - 450) / 130), 5, 8);
            Debug.Log($"counter: {counter}; time: {time};");
            NewLevel();
        }
        time -= Time.deltaTime;
    }
    [ContextMenu("ChangeLevel")]
    public void ChangeLevel()
    {
        ScrollingBackground.changeBackground = !ScrollingBackground.changeBackground;
    }
    [ContextMenu("New Level")]
    public void NewLevel()
    {
        if (IsReady())
        { 
            if (counter % 32 < 32 && counter % 30 > 10)
                Instantiate(LinkToObjects.instance.miniLevels[Random.Range(0, LinkToObjects.instance.miniLevels.Length)], parent);
            else
                Instantiate(LinkToObjects.instance.miniLevels[Random.Range(0, LinkToObjects.instance.stationLevels.Length)], parent);
        }
    }
    private bool IsReady()
    {
        foreach (Transform child in parent)
        {
            if (child.childCount == 0)
                Destroy(child.gameObject);
        }

        if (!(ScrollingBackground.isChanged & ScrollingBackground.changeBackground) && counter % 30 == 0
            || ScrollingBackground.isChanged & ScrollingBackground.changeBackground && counter % 35 == 0) // может убрать проверку по counter
            ChangeLevel();

        switch (parent.childCount)
        {
            case 0:
                return true;
                case 1:
                if (Random.value > .25f) return true;
                else return false;
            case 2:
                if (Random.value > .5f) return true;
                else return false;
            case 3:
                if (Random.value > .75f) return true;
                else return false;
        }

        return false;
    }
}
