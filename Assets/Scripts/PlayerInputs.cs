using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    private TextMeshProUGUI m_charName;

    RaycastHit hit;

    private void Start()
    {
        m_charName.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "NPC" && !TextBox.Instance.IsPlaying)
            {
                m_charName.text = hit.collider.gameObject.name;
                m_charName.gameObject.SetActive(true);
                m_charName.gameObject.transform.position = Input.mousePosition;
                //Debug.Log("This is a NPC");

                if (Input.GetButtonDown("Fire1"))
                {
                    hit.transform.gameObject.GetComponent<NPCStartMonologue>().SayHello();
                    UIManager.Instance.m_WoodCount--;
                    if(UIManager.Instance.m_WoodCount == 0)
                    {
                        UIManager.Instance.LoadMinigame();
                    }
                }
            }
        }
        else
        {
            m_charName.gameObject.SetActive(false);
        }

    }

    public void OnClick(InputAction.CallbackContext _context)
    {
        //Debug.Log("missssssssss");
        if (_context.started)
        {
            //RAYCASTEN HIER
            if (Physics.Raycast(Input.mousePosition, cam.ScreenToWorldPoint(Input.mousePosition), out hit, 10000, 6))
            {
                Debug.Log("hit");
                hit.transform.gameObject.GetComponent<NPCStartMonologue>().SayHello();
            }
            else
            {
                Debug.Log("miss");
            }
        }
        else
        {
        }
    }
}
