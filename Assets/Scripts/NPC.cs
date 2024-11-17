using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "NPC")]
public class NPC : ScriptableObject
{
    public new string name;
    public int weight;
    public Sprite artwork;
}
