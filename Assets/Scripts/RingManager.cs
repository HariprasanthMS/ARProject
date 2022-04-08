using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    [SerializeField]
    private FingerInfoGizmo fingerInfoGizmo;
    public GameObject warningPanel;
    public GameObject finger;
    public GameObject ringPrefab;

    private GameObject ring;

    // Start is called before the first frame update
    void Start()
    {
        ring = Instantiate(ringPrefab);
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(true);

        Screen.orientation = ScreenOrientation.Portrait;
        GameObject.Find("Finger").SetActive(false);

        if (fingerInfoGizmo==null)
        {
            try
            {
                fingerInfoGizmo = GameObject.Find("TryOnManager").GetComponent<FingerInfoGizmo>();
                finger = GameObject.Find("Finger");
            }
            catch
            {
                Debug.Log("APP: Cant find 'TryOnManager' GameObject");   
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManomotionManager.Instance.ShouldRunFingerInfo(true);

        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_class == ManoClass.GRAB_GESTURE)
        {
            Debug.Log("Depth: " + ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation + " ");
            if(ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation > 0.5)
            {
                ShowRing();
            }
            else
            {
                HideRing("Hand is too close");
            }
        }
        else
        {
            HideRing("Show your hand open");
        }
    }

    void ShowRing()
    {
        warningPanel.SetActive(false);
        fingerInfoGizmo.ShowFingerInformation();
        float centerPosition = 0.5f;
        Vector3 ringPlacement = Vector3.Lerp(fingerInfoGizmo.LeftFingerPoint3DPosition, fingerInfoGizmo.RightFingerPoint3DPosition, centerPosition);

        Debug.Log("Setting ring active");
        ring.SetActive(true);
        ring.transform.LookAt(fingerInfoGizmo.LeftFingerPoint3DPosition);
        ring.transform.localScale = new Vector3(fingerInfoGizmo.WidthBetweenFingerPoints / 2, fingerInfoGizmo.WidthBetweenFingerPoints, fingerInfoGizmo.WidthBetweenFingerPoints) / 2;

        if(ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.hand_side == HandSide.Palmside)
        {
            ring.transform.localScale = new Vector3(-ring.transform.localScale.x, -ring.transform.localScale.y, -ring.transform.localScale.z);
        }

        Debug.Log("Finger info at " + ringPlacement);
        // finger.transform.position = ringPlacement;
    }

    private void HideRing(string message)
    {
        //if(finger) 
        // finger.SetActive(false);
        ring.SetActive(false);

        if (warningPanel)
        {
            Debug.Log("Warning panel not null");
            warningPanel.SetActive(true);
            //warningPanel.GetComponent<TMPro.TextMeshProUGUI>().text = message;
            //Debug.Log(warningPanel.GetComponent<TMPro.TextMeshProUGUI>().text);
        }
        else
        {
            Debug.Log(warningPanel + " not found");
        }
    }
}
