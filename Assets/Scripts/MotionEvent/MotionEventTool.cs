using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionEventTool : MonoBehaviour
{
    [SerializeField]
    private Animator targetActorAnimator = null;

    [SerializeField]
    private MotionListItem listItemTemplate = null;

    [SerializeField]
    private Transform motionListParent = null;

    [SerializeField]
    private MotionClipSamplingPanel samplingPanel = null;

<<<<<<< Updated upstream
=======
    [SerializeField]
    private MotionEventPanel eventPanel = null;

>>>>>>> Stashed changes
    private GameObject samplingActor = null;

    private AnimationClip[] motionClips = null;

    private AnimationClip currentClip = null;

<<<<<<< Updated upstream
=======
    public float CurrentFrame { private set; get; } = 0f;

>>>>>>> Stashed changes
    void Start()
    {
        motionClips = targetActorAnimator?.runtimeAnimatorController.animationClips;
        samplingActor = targetActorAnimator?.gameObject;
        samplingPanel.SetOnSamplingValueChange(PlaySamplingAnim);
        LoadAllMotion();
    }

    void LoadAllMotion()
    {
        if (motionClips == null) 
        {
            listItemTemplate.gameObject.SetActive(false);
            return;
        }

        foreach(AnimationClip motionClip in motionClips)
        {
            GameObject newListItem = Instantiate(listItemTemplate.gameObject, motionListParent);
            MotionListItem mli = newListItem.GetComponent<MotionListItem>();
            string clipName = motionClip.name;

            if (clipName.Equals("idle"))
            {
                currentClip = motionClip;
                PlaySamplingAnim(0f);
                samplingPanel.SetSamplingClip(currentClip);
<<<<<<< Updated upstream
=======
                eventPanel.Setup(motionClip, this);
>>>>>>> Stashed changes
            }

            mli.Setup(clipName, () => {
                currentClip = motionClip;
                PlaySamplingAnim(0f);
                samplingPanel.SetSamplingClip(currentClip);
<<<<<<< Updated upstream
=======
                eventPanel.Setup(motionClip, this);
>>>>>>> Stashed changes
            });
        }

        listItemTemplate.gameObject.SetActive(false);
    }

    void PlaySamplingAnim(float targetFrame)
    {
        if (currentClip == null) { return; }
        
        if (targetActorAnimator != null)
        {
            if (targetActorAnimator.enabled)
                targetActorAnimator.enabled = false;
        }

        currentClip.SampleAnimation(samplingActor, targetFrame);
<<<<<<< Updated upstream
=======

        CurrentFrame = targetFrame;
>>>>>>> Stashed changes
    }

    
}
