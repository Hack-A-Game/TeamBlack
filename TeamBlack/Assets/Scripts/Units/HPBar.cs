using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {
    public GameObject Empty;
    public GameObject Full;
    public void updateHP(float newLife,float maxHP,Vector3 location)
    {
        Full.transform.position = new Vector3(location.x,location.y + 1,location.z-1);
        //Empty.transform.position = new Vector3(location.x, location.y + 1, location.z);
        Destroy(Empty);
        Full.transform.localScale = new Vector3( 0.05f*(newLife / maxHP),Full.transform.localScale.y,1);
    }
}
//public HPBar bar; <--A Unit.cs
/*if (bar != null) <-- A cadascuna de les unitats
{
    bar.updateHP(HP, maxHP,transform.position);
}*/
