using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangarPanelUI : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] Text timer;
    [SerializeField] Text fixedShips;
    [SerializeField] Text missedShips;
    [SerializeField] Text points;

    [SerializeField] List<GameObject> lifeCounter;

    private void OnEnable()
    {
        gameData.onTimerChange += UpdateTimer;
        gameData.onFixedShipsChange += UpdateFixedShips;
        gameData.onMissedShipsChange += UpdateMissedShips;
        gameData.onLifesChange += UpdateLifes;
        gameData.onPointsChange += UpdatePoints;
    }

    private void OnDisable()
    {
        gameData.onTimerChange -= UpdateTimer;
        gameData.onFixedShipsChange -= UpdateFixedShips;
        gameData.onMissedShipsChange -= UpdateMissedShips;
        gameData.onLifesChange -= UpdateLifes;
        gameData.onPointsChange -= UpdatePoints;
    }

    public void UpdateTimer(int value)
    {
        timer.text = value.ToString();
    }

    public void UpdateFixedShips(int value)
    {
        fixedShips.text = value.ToString();
    }

    public void UpdateMissedShips(int value)
    {
        missedShips.text = value.ToString();
    }

    public void UpdateLifes(int value)
    {
        for (int i = 0; i < lifeCounter.Count; i++)
        {
            if (i + 1 <= value)
                lifeCounter[i].SetActive(true);
            else
                lifeCounter[i].SetActive(false);
        }
    }

    public void UpdatePoints(int value)
    {
        points.text = value.ToString();
    }
}
