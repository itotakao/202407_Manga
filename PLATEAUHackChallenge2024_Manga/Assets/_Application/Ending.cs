using _Util;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Ending : MonoBehaviour
{
    private FadeManager FadeManager => FadeManager.Current;

    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField]
    private TextMeshProUGUI endingText;

    private CinemachineTrackedDolly _dolly;

    // Start is called before the first frame update
    void Start()
    {
        _dolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _dolly.m_PathPosition += 0.05f * Time.deltaTime;

        if (_dolly.m_PathPosition >= 0.8f)
        {
            FadeManager.isFadeOut = true;
            endingText.gameObject.SetActive(true);
            endingText.color = new Color(endingText.color.r, endingText.color.g, endingText.color.b,endingText.color.a + 0.05f*Time.deltaTime);
        }
    }
}
