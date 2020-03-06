using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Valve.VR;

public class Video : MonoBehaviour
{
    public SteamVR_Action_Vibration hapticAction;
    public SteamVR_Action_Boolean trackpadAction;
    public RawImage rawImage;
    public VideoPlayer videoplayer;
    public TextMeshProUGUI panelHolder;
    [SerializeField] TextMeshProUGUI chat_side;
    [SerializeField] TextMeshProUGUI chat_over;
    [SerializeField] TextMeshProUGUI chat_bottom;
    [SerializeField] TextMeshProUGUI chat_FOV;
    [SerializeField] TextMeshProUGUI chat_controller;
    [SerializeField] public int condition;  // condition 0 = right side, 1 = bottom, 2 = on screen bottom, 3 = attached to controller, 4 = FOV
    public int video;
    public Renderer chat_side_plane;
    public int[] interval_0;
    public int[] interval_1;
    public int[] interval_2;
    public int[] interval_3;
    public int[] interval_4;
    public int[] interval;
    public string[] questions_C0;
    public string[] questions_C1;
    public string[] questions_C2;
    public string[] questions_C3;
    public string[] questions_C4;
    public string[] final_questions = new string[5] { "", "", "", "", "" };
    public int audio_identifier = 0;
    public int delay = 5;
    public static AudioClip sound;
    static AudioSource audioSrc;

    //public AudioSource audioSource_nature;
    // Use this for initialization

    private void Start()
    {
        Reset();
        rawImage.color = Color.black;

        interval_0 = new int[] { 25, 48, 55, 111, 119 };
        interval_1 = new int[] { 25, 40, 55, 95, 105 };
        interval_2 = new int[] { 27, 35, 75, 85, 110 };
        interval_3 = new int[] { 5, 14, 27, 35, 90 };
        interval_4 = new int[] { 43, 52, 77, 86, 110 };

        questions_C0 = new string[] { "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Q1Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!_A", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!" };
        questions_C1 = new string[] { "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Q1Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!_A", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!" };
        questions_C2 = new string[] { "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Q1Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!_A", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!" };
        questions_C3 = new string[] { "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Q1Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!_A", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!" };
        questions_C4 = new string[] { "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Q1Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!_A", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!", "Lorem Ipsum, Hello Xuesong - Wie geht es dir? Okay, passt!" };
    }
    void Update()
    {
        if (Input.GetKey("c") || Input.GetKey("v") || Input.GetKey("b") || Input.GetKey("n") || Input.GetKey("m"))
        {
            Reset();
            rawImage.color = Color.white;

        }
        if (Input.GetKey("c"))
        {
            video = 0;
            final_questions = questions_C0;
            videoplayer.url = "assets/study_material/video_nature_1.mp4";
            StartCoroutine(PlayVideo(videoplayer));
        }
        if (Input.GetKey("v"))
        {
            video = 1;
            final_questions = questions_C1;
            videoplayer.url = "assets/study_material/video_nature_2.mp4";
            StartCoroutine(PlayVideo(videoplayer));

        }
        if (Input.GetKey("b"))
        {
            video = 2;
            final_questions = questions_C2;
            videoplayer.url = "assets/study_material/video_nature_3.mp4";
            StartCoroutine(PlayVideo(videoplayer));
        }
        if (Input.GetKey("n"))
        {
            video = 3;
            final_questions = questions_C3;
            videoplayer.url = "assets/study_material/video_nature_4.mp4";
            StartCoroutine(PlayVideo(videoplayer));

        }
        if (Input.GetKey("m"))
        {
            video = 4;
            final_questions = questions_C4;
            videoplayer.url = "assets/study_material/video_nature_5.mp4";
            StartCoroutine(PlayVideo(videoplayer));

        }
        if (Mathf.RoundToInt((float)videoplayer.time) == 120)
        {
            videoplayer.Stop();
            rawImage.color = Color.black;

        }

        setText();
    }
    IEnumerator PlayVideo(VideoPlayer videoPlayer)
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;

        videoPlayer.Play();
        //audioSource.Play();
    }



    public void setText()
    {
        switch (condition)
        {
            case 0:
                panelHolder = chat_side;
                break;
            case 1:
                panelHolder = chat_bottom;
                break;
            case 2:
                panelHolder = chat_over;
                break;
            case 3:
                panelHolder = chat_FOV;
                break;
            case 4:
                panelHolder = chat_controller;
                break;
            default:
                break;
        }
        switch (video)
        {
            case 0:
                interval = interval_0;
                final_questions = questions_C0;
                break;
            case 1:
                interval = interval_1;
                final_questions = questions_C1;
                break;
            case 2:
                interval = interval_2;
                final_questions = questions_C2;

                break;
            case 3:
                interval = interval_3;
                final_questions = questions_C3;

                break;
            case 4:
                interval = interval_4;
                final_questions = questions_C4;
                break;
            default:
                break;
        }
        
        if (Mathf.RoundToInt((float)videoplayer.time) == interval[0])
        {
            panelHolder.text = final_questions[0];
            if (condition == 4)
            {
                // duration, frequency, amplitude
                Pulse(1, 150, 150, SteamVR_Input_Sources.LeftHand);
            }
        }
        if (Mathf.RoundToInt((float)videoplayer.time) == interval[1])
        {
            panelHolder.text = final_questions[1];
            if (condition == 4)
            {
                // duration, frequency, amplitude
                Pulse(1, 150, 150, SteamVR_Input_Sources.LeftHand);
            }
        }
        if (Mathf.RoundToInt((float)videoplayer.time) == interval[2])
        {
            panelHolder.text = final_questions[2];
            if (condition == 4)
            {
                // duration, frequency, amplitude
                Pulse(1, 150, 150, SteamVR_Input_Sources.LeftHand);
            }
        }
        if (Mathf.RoundToInt((float)videoplayer.time) == interval[3])
        {
            panelHolder.text = final_questions[3];
            if (condition == 4)
            {
                // duration, frequency, amplitude
                Pulse(1, 150, 150, SteamVR_Input_Sources.LeftHand);
            }
        }
        if (Mathf.RoundToInt((float)videoplayer.time) == interval[4])
        {
            panelHolder.text = final_questions[4];
            if (condition == 4)
            {
                // duration, frequency, amplitude
                Pulse(1, 150, 150, SteamVR_Input_Sources.LeftHand);
            }
        }

        if ((Mathf.RoundToInt((float)videoplayer.time) == interval[0] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[1] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[2] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[3] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[4] + delay))
        {
            panelHolder.text = "";
        }

    }

    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
    }

    public void Reset()
    {
        chat_side.text = "";
        chat_over.text = "";
        chat_bottom.text = "";
        chat_FOV.text = "";
        chat_controller.text = "";
    }


}