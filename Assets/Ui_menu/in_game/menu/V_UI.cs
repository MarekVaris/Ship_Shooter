using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Slider>().value = AudioListener.volume;
    }

    public void Change_valume()
    {
        AudioListener.volume = gameObject.GetComponent<Slider>().value;
        Save_sys.instance.Valume_settings = gameObject.GetComponent<Slider>().value;
        Save_sys.instance.Save();
    }


}
