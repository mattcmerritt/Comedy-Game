using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Joke
{
    public ComedyType Type;
    [TextArea] public string Content;
}
