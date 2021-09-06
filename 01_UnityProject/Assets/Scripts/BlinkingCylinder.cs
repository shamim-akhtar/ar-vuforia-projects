using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingCylinder : MonoBehaviour
{
  [SerializeField]
  Renderer[] MarkersInOrder;
  [SerializeField]
  Color ActiveColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
  [SerializeField]
  Color InActiveColor = new Color(1.0f, 1.0f, 200 / 255.0f, 1.0f);

  public bool Enabled { get; set; } = true;
  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(Coroutine_BlinkInOrder());
  }

  IEnumerator Coroutine_BlinkInOrder()
  {
    while(Enabled)
    {
      for(int i = 0; i < MarkersInOrder.Length; ++i)
      {
        Blink(i);
        yield return new WaitForSeconds(0.5f);
      }
      yield return new WaitForSeconds(2.0f);
    }
  }

  void Blink(int id)
  {
    for(int i = 0; i < MarkersInOrder.Length; ++i)
    {
      MarkersInOrder[i].material.color = InActiveColor;
    }
    Material mat = MarkersInOrder[id].material;
    if(mat)
    {
      MarkersInOrder[id].material.color = ActiveColor;
    }
  }
}
