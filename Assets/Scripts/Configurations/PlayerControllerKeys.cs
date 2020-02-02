using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Configurations/Player Input")]
public class PlayerControllerKeys : ScriptableObject
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode pickKey;
    public KeyCode dropKey;
}
