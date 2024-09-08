using _Util;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public static Ending Current;

    private FadeManager FadeManager => FadeManager.Current;

    private bool isEnabled = false;
    private float animationSpeed = 0.02f;

    [SerializeField]
    private GameObject selfRig;
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField]
    private TextMeshProUGUI endingText;

    private CinemachineTrackedDolly _dolly;

    private void Awake()
    {
        Current = this;
        selfRig.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _dolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isEnabled)
        {
            return;
        }

        _dolly.m_PathPosition += animationSpeed * Time.deltaTime;

        if (_dolly.m_PathPosition >= 0.8f)
        {
            FadeManager.isFadeOut = true;
            endingText.gameObject.SetActive(true);
            endingText.color = new Color(endingText.color.r, endingText.color.g, endingText.color.b,endingText.color.a + 0.05f*Time.deltaTime);
        }
    }

    public void PlayEnding()
    {
        isEnabled = true;
        selfRig.SetActive(true);
    }
}
