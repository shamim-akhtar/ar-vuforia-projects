using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBarrierHeight : MonoBehaviour
{

  public LayerMask mLayerMask;

  // Distance to cast ray
  public float mRaycastDistance = 10000f;

  public GameObject[] Barriers;
  private string[] mInformation =
  {
    "You have selected <color=yellow><b>Chest level</b></color>." +
      "\n" + "\n" + "Please click on Confirm to submit you answer.",
    "You have selected <color=yellow><b>Waist level</b></color>. " +
      "\n" + "\n" + "Please click on Confirm to submit you answer.",
    "You have selected <color=yellow><b>Knee level</b></color>. " +
      "\n" + "\n" + "Please click on Confirm to submit you answer.",
    "You have selected <color=yellow><b>Ankle level</b></color>. " +
      "\n" + "\n" + "Please click on Confirm to submit you answer.",
  };
  public Text MessageText;
  public GameObject MessagePanel;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Pick();
    }
  }

  private void Select(int id)
  {
    Barriers[0].SetActive(false);
    Barriers[1].SetActive(false);
    Barriers[2].SetActive(false);
    Barriers[3].SetActive(false);

    Barriers[id].SetActive(true);
    if(MessageText)
    {
      MessageText.text = mInformation[id];
      if (MessagePanel)
      {
        StartCoroutine(Coroutine_ShowInformation(5.0f));
      }
    }
  }

  IEnumerator Coroutine_ShowInformation(float duration)
  {
    MessagePanel.SetActive(true);
    yield return new WaitForSeconds(duration);
    MessagePanel.SetActive(false);
  }

  void Pick()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

    RaycastHit hitInfo;

    if (Physics.Raycast(ray.origin, ray.direction, out hitInfo, mRaycastDistance, mLayerMask))
    {
      Debug.Log("Hit: " + hitInfo.collider.name);
      if (hitInfo.collider.name == "Part1") 
      {
        Select(0);
      }
      else if(hitInfo.collider.name == "Part2")
      {
        Select(1);
      }
      else if (hitInfo.collider.name == "Part3")
      {
        Select(2);
      }
      else if (hitInfo.collider.name == "Part4")
      {
        Select(3);
      }
    }
    else
    {
      Debug.Log("No hit");
    }
  }
}
