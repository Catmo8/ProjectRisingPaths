using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ModeSelect")]
public class ModeSelect : ScriptableObject
{
    public static bool localPlay = false;
    public static bool networkCreator = false;
    public static bool networkLittleGuy = false;
}
