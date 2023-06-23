using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PickAction : MonoBehaviour
{
  public void CharacterAct()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Pick");
    }
}
