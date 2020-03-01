using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommunicationController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;

    // Start is called before the first frame update
   

    // Update is called once per frame
  

  
    private void Update()
    {
        var input = Input.inputString;
        switch (input)
        {
            case "1":
                m_Object.text = "Paul: Hi Lea!";
                break;
            case "2":
                m_Object.text += "\nPaul: Yes!";
                break;
                default: break;
        }
    }
}
