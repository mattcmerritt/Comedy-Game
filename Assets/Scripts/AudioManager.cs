using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Voice bank reference: 1-Spencer, 2-Callandra, 3-Kyle, 4-Annie, 5-Amari

    [SerializeField] List<AudioClip> KingClips = new List<AudioClip>();
    [SerializeField] List<AudioClip> CrowdClips = new List<AudioClip>();

    //organizes hiring audio per voice bank
    [SerializeField] List<AudioClip> JHire1 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JHire2 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JHire3 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JHire4 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JHire5 = new List<AudioClip>();

    //organizes performance success audio per voice bank
    [SerializeField] List<AudioClip> JPerfGood1 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfGood2 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfGood3 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfGood4 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfGood5 = new List<AudioClip>();

    //organizes performance fail / lived audio per voice bank
    [SerializeField] List<AudioClip> JPerfBad1 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfBad2 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfBad3 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfBad4 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JPerfBad5 = new List<AudioClip>();

    //organizes death audio per voice bank
    [SerializeField] List<AudioClip> JDeath1 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JDeath2 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JDeath3 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JDeath4 = new List<AudioClip>();
    [SerializeField] List<AudioClip> JDeath5 = new List<AudioClip>();

    //returns an audio clip of the king, depending on pass/fail/death
    public AudioClip GetKingClip(int status)
    {
        //currently 1-success, 2-fail, 3-snake pit
        return KingClips[status];
    }

    //returns an audio clip of the crowd, depending on reaction
    public AudioClip GetCrowdClip(int status)
    {
        return CrowdClips[status];
    }

    //returns a hiring audio clip randomized from the requested voice bank
    public AudioClip GetHiringClip(int voicebank)
    {
        AudioClip toReturn = null;
        int ran = 0;
        switch (voicebank)
        {
            case 1:
                 ran = Random.Range(0, JHire1.Count);
                toReturn = JHire1[ran];
                break;
            case 2:
                 ran = Random.Range(0, JHire2.Count);
                toReturn = JHire2[ran];
                break;
            case 3:
                ran = Random.Range(0, JHire3.Count);
                toReturn = JHire3[ran];
                break;
            case 4:
                ran = Random.Range(0, JHire4.Count);
                toReturn = JHire4[ran];
                break;
            case 5:
                ran = Random.Range(0, JHire5.Count);
                toReturn = JHire5[ran];
                break;
            default:
                ran = Random.Range(0, JHire1.Count);
                toReturn = JHire1[ran];
                break;
        }

        return toReturn;
    }


    //returns a successful performance audio clip randomized from the requested voice bank
    public AudioClip GetPerfGoodClip(int voicebank)
    {
        AudioClip toReturn = null;
        int ran = 0;
        switch (voicebank)
        {
            case 1:
                ran = Random.Range(0, JPerfGood1.Count);
                toReturn = JPerfGood1[ran];
                break;
            case 2:
                ran = Random.Range(0, JPerfGood2.Count);
                toReturn = JPerfGood2[ran];
                break;
            case 3:
                ran = Random.Range(0, JPerfGood3.Count);
                toReturn = JPerfGood3[ran];
                break;
            case 4:
                ran = Random.Range(0, JPerfGood4.Count);
                toReturn = JPerfGood4[ran];
                break;
            case 5:
                ran = Random.Range(0, JPerfGood5.Count);
                toReturn = JPerfGood5[ran];
                break;
            default:
                ran = Random.Range(0, JPerfGood1.Count);
                toReturn = JPerfGood1[ran];
                break;
        }

        return toReturn;
    }

    //returns a failed performance audio clip randomized from the requested voice bank
    public AudioClip GetPerfBadClip(int voicebank)
    {
        AudioClip toReturn = null;
        int ran = 0;
        switch (voicebank)
        {
            case 1:
                ran = Random.Range(0, JPerfBad1.Count);
                toReturn = JPerfBad1[ran];
                Debug.Log(ran);
                break;
            case 2:
                ran = Random.Range(0, JPerfBad2.Count);
                toReturn = JPerfBad2[ran];
                break;
            case 3:
                ran = Random.Range(0, JPerfBad3.Count);
                toReturn = JPerfBad3[ran];
                Debug.Log(ran);
                break;
            case 4:
                ran = Random.Range(0, JPerfBad4.Count);
                toReturn = JPerfBad4[ran];
                Debug.Log(ran);
                break;
            case 5:
                ran = Random.Range(0, JPerfBad5.Count);
                toReturn = JPerfBad5[ran];
                break;
            default:
                ran = Random.Range(0, JPerfBad1.Count);
                toReturn = JPerfBad1[ran];
                break;
        }
        Debug.Log(ran);
        return toReturn;
    }

    //returns a hiring audio clip randomized from the requested voice bank
    public AudioClip GetDeathClip(int voicebank)
    {
        AudioClip toReturn = null;
        int ran = 0;
        switch (voicebank)
        {
            case 1:
                ran = Random.Range(0, JDeath1.Count);
                toReturn = JDeath1[ran];
                break;
            case 2:
                ran = Random.Range(0, JDeath2.Count);
                toReturn = JDeath2[ran];
                break;
            case 3:
                ran = Random.Range(0, JDeath3.Count);
                toReturn = JDeath3[ran];
                break;
            case 4:
                ran = Random.Range(0, JDeath4.Count);
                toReturn = JDeath4[ran];
                break;
            case 5:
                ran = Random.Range(0, JDeath5.Count);
                toReturn = JDeath5[ran];
                break;
            default:
                ran = Random.Range(0, JDeath1.Count);
                toReturn = JDeath1[ran];
                break;
        }

        return toReturn;
    }

    /**
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }**/
}
