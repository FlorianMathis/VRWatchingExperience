using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoplayer;
    [SerializeField] TextMeshProUGUI chat_side;
    [SerializeField] TextMeshProUGUI chat_over;
    [SerializeField] public int condition;
    public Renderer chat_side_plane;
    public int[] interval;
    public string[] questions_C1;
    public string[] questions_C2;
    public string[] questions_C3;
    public string[] final_questions = new string[7] {"","","","","","","" };
    public int audio_identifier = 0;
    public int delay = 3;
    public static AudioClip sound;
    static AudioSource audioSrc;

    //public AudioSource audioSource_nature;
    // Use this for initialization

    private void Start()
    {
        interval = new int[] { 5, 15, 25, 45, 75, 90, 110 };
        questions_C1 = new string[] { "Q1_A", "Q1_A", "Q1_A", "Q1_A", "Q1_A", "Q1_A", "Q1_A"};
        questions_C2 = new string[] { "Q1_B", "Q1_B", "Q1_B", "Q1_B", "Q1_B", "Q1_B", "Q1_B"};
        questions_C3 = new string[] { "Q1_C", "Q1_C", "Q1_C", "Q1_C", "Q1_C", "Q1_C", "Q1_C"};

    }
    void Update()
    {
        if (Input.GetKey("c"))
        {
            audio_identifier = 1;
            final_questions = questions_C1;
            videoplayer.url = "D:/Dokumente/PhD/_FirstYear/unity/IMX short paper/Assets/study_material/video_nature_1.mp4";
            StartCoroutine(PlayVideo(videoplayer));
        }
        if (Input.GetKey("v"))
        {
            audio_identifier = 2;

            final_questions = questions_C2;

            videoplayer.url = "D:/Dokumente/PhD/_FirstYear/unity/IMX short paper/Assets/study_material/video_nature_2.mp4";
            StartCoroutine(PlayVideo(videoplayer));

        }
        if (Input.GetKey("b"))
        {
            audio_identifier = 3;

            final_questions = questions_C3;

            videoplayer.url = "D:/Dokumente/PhD/_FirstYear/unity/IMX short paper/Assets/study_material/video_nature_3.mp4";
            StartCoroutine(PlayVideo(videoplayer));

        }
        if (Mathf.RoundToInt((float)videoplayer.time) == 120)
        {
            videoplayer.Stop();
        }
        if (condition == 1)
        {
            chat_side_plane.GetComponent<Renderer>().enabled = true;
            chat_over.text = "";
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[0])
            {
                chat_side.text = final_questions[0];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[1])
            {
                chat_side.text = final_questions[0]+ final_questions[1];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[2])
            {
                chat_side.text = final_questions[0] + final_questions[1]+ final_questions[2];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[3])
            {
                chat_side.text = final_questions[0] + final_questions[1] + final_questions[2]+ final_questions[3];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[4])
            {
                chat_side.text += final_questions[0] + final_questions[1] + final_questions[2] + final_questions[3]+ final_questions[4];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[5])
            {
                chat_side.text += final_questions[0] + final_questions[1] + final_questions[2] + final_questions[3]+ final_questions[5];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[6])
            {
                chat_side.text += final_questions[0] + final_questions[1] + final_questions[2] + final_questions[3]+ final_questions[6];

            }
        }
         else if(condition == 2)
        {
            chat_side_plane.GetComponent<Renderer>().enabled = false;
            chat_side.text = "";
            if((Mathf.RoundToInt((float)videoplayer.time) == interval[0]+delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[1] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[2] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[3] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[4] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[5] + delay) ||
                (Mathf.RoundToInt((float)videoplayer.time) == interval[6] + delay))
            {
                chat_over.text = "";
            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[0])
            {
                chat_over.text = final_questions[0];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[1])
            {
                chat_over.text = final_questions[1];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[2])
            {
                chat_over.text = final_questions[2];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[3])
            {
                chat_over.text = final_questions[3];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[4])
            {
                chat_over.text = final_questions[4];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[5])
            {
                chat_over.text = final_questions[5];

            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[6])
            {
                chat_over.text = final_questions[6];

            }
        }
        else if (condition == 3) //audio
        {
            chat_side_plane.GetComponent<Renderer>().enabled = false;
            chat_side.text = "";
            chat_over.text = "";
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[0])
            {
                switch (audio_identifier)
                {
                    case 1:
                        sound = Resources.Load<AudioClip>("movie1_q1");
                        break;
                    case 2:
                        sound = Resources.Load<AudioClip>("movie2_q1");
                        break;
                    case 3:
                        sound = Resources.Load<AudioClip>("movie3_q1");
                        break;
                    default:
                        break;
                  }

                    audioSrc = GetComponent<AudioSource>();
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(sound);
                }
            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[1])
            {
                switch (audio_identifier)
                {
                    case 1:
                        sound = Resources.Load<AudioClip>("movie1_q2");
                        break;
                    case 2:
                        sound = Resources.Load<AudioClip>("movie2_q2");
                        break;
                    case 3:
                        sound = Resources.Load<AudioClip>("movie3_q2");
                        break;
                    default:
                        break;
                }
                audioSrc = GetComponent<AudioSource>();
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(sound);
                }
            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[2])
            {
                switch (audio_identifier)
                {
                    case 1:
                        sound = Resources.Load<AudioClip>("movie1_q3");
                        break;
                    case 2:
                        sound = Resources.Load<AudioClip>("movie2_q3");
                        break;
                    case 3:
                        sound = Resources.Load<AudioClip>("movie3_q3");
                        break;
                    default:
                        break;
                }
                audioSrc = GetComponent<AudioSource>();
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(sound);
                }
            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[3])
            {
                switch (audio_identifier)
                {
                    case 1:
                        sound = Resources.Load<AudioClip>("movie1_q4");
                        break;
                    case 2:
                        sound = Resources.Load<AudioClip>("movie2_q4");
                        break;
                    case 3:
                        sound = Resources.Load<AudioClip>("movie3_q4");
                        break;
                    default:
                        break;
                }
                audioSrc = GetComponent<AudioSource>();
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(sound);
                }
            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[4])
            {
                switch (audio_identifier)
                {
                    case 1:
                        sound = Resources.Load<AudioClip>("movie1_q5");
                        break;
                    case 2:
                        sound = Resources.Load<AudioClip>("movie2_q5");
                        break;
                    case 3:
                        sound = Resources.Load<AudioClip>("movie3_q5");
                        break;
                    default:
                        break;
                }
                audioSrc = GetComponent<AudioSource>();
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(sound);
                }
            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[5])
            {
                switch (audio_identifier)
                {
                    case 1:
                        sound = Resources.Load<AudioClip>("movie1_q6");
                        break;
                    case 2:
                        sound = Resources.Load<AudioClip>("movie2_q6");
                        break;
                    case 3:
                        sound = Resources.Load<AudioClip>("movie3_q6");
                        break;
                    default:
                        break;
                }
                audioSrc = GetComponent<AudioSource>();
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(sound);
                }
            }
            if (Mathf.RoundToInt((float)videoplayer.time) == interval[6])
            {
                switch (audio_identifier)
                {
                    case 1:
                        sound = Resources.Load<AudioClip>("movie1_q7");
                        break;
                    case 2:
                        sound = Resources.Load<AudioClip>("movie2_q7");
                        break;
                    case 3:
                        sound = Resources.Load<AudioClip>("movie3_q7");
                        break;
                    default:
                        break;
                }
                audioSrc = GetComponent<AudioSource>();
                if (!audioSrc.isPlaying)
                {
                    audioSrc.PlayOneShot(sound);
                }
            }
        }
        
        
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

}