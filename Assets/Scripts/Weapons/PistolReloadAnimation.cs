using UnityEngine;

public class PistolReloadAnimation : MonoBehaviour
{
    public GameObject leftHand;
    public MeshRenderer originalMag;
    public MeshRenderer newMag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartReload()
    {
        print("start reload called");
        leftHand.SetActive(true);
        newMag.enabled = true;
    }

    public void HideOriginalMag()
    {
        print("hide original mag called");
        originalMag.enabled = false;
    }


    public void EndReload()
    {
        print("end reload called");
        leftHand.SetActive(false);
        originalMag.enabled = true;
        newMag.enabled = false;
    }


}
