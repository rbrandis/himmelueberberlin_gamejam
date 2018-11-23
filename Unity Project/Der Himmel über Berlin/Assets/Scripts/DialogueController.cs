using System.Collections.Generic;
using System.Linq;
using Articy.Der_Himmel_Ueber_Berlin;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour, IArticyFlowPlayerCallbacks
{
    [SerializeField] private Text _speakerTextElement;
    [SerializeField] private bool _showFalseBranches;

    private ArticyFlowPlayer _flowPlayer;
    private RectTransform _transform;
    private float _timer;

    public bool IsPlaying { get; private set; }

    public static DialogueController Instance { get; private set; }
    public float TextDisplayTime = 2.0f;

    public GameObject TextDisplay;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple dialogue controllers in scene.");
        }

        Instance = this;
        _flowPlayer = GetComponent<ArticyFlowPlayer>();
        _transform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _speakerTextElement.text = string.Empty;
        ArticyDatabase.DefaultGlobalVariables.ResetVariables();
    }

    private void Update()
    {
        if (!IsPlaying) return;
        _timer -= Time.deltaTime;
        if (_timer > 0) return;
        CloseDialogue();
        IsPlaying = false;
    }

    public void StartDialogue(IArticyObject flowObject)
    {
        IsPlaying = true;
        TextDisplay.SetActive(true);
        _timer = TextDisplayTime;

        //TODO FADE IN
        _flowPlayer.StartOn = flowObject;
        //LeanTween.moveY(_transform, 0f, 0.5f).setEaseOutSine();
    }

    //private void AddOption(Branch branch, int optionIdx)
    //{
    //    var option = Instantiate(_optionPrefab, Vector3.zero, Quaternion.identity, _playerOptionRoot);
    //    var optionComp = option.GetComponent<DialogueOption>();
    //    optionComp.Set(branch, this, optionIdx);
    //}

    public void OnFlowPlayerPaused(IFlowObject aObject)
    {
        var dlgFrg = aObject as DialogueFragment;
        if (dlgFrg != null)
        {
            _speakerTextElement.text = dlgFrg.Text;
        }
        else
        {
            if(aObject != null) _flowPlayer.Play();
        }
    }

    public void OnBranchesUpdated(IList<Branch> aBranches)
    {
        //ClearOptions();
        
        //var dialogIsFinished = !aBranches.Any(aObj => aObj.Target is IDialogueFragment); //aBranches.Count <= 0; //

        //if (!dialogIsFinished)
        //{
        //    for (var optionIdx = 0; optionIdx < aBranches.Count; optionIdx++)
        //    {
        //        var branch = aBranches[optionIdx];
        //        if (!branch.IsValid && !_showFalseBranches) continue;

        //        AddOption(branch, optionIdx + 1);
        //    }
        //}
        //else
        //{
        //    AddOption(null, 1);
        //}
    }

    //public void PlayBranch(Branch branch)
    //{
    //    if (branch != null)
    //    {
    //        _flowPlayer.Play(branch);
    //    }
    //    else
    //    {
            
    //        CloseDialogue();
    //    }
    //}

    private void CloseDialogue()
    {
        _flowPlayer.FinishCurrentPausedObject();
        //TODO FADE OUT
        TextDisplay.SetActive(false);

        //LeanTween.moveY(_transform, -_transform.rect.height, 0.5f).setEaseOutSine();
        //ClearOptions();
    }

    public bool IsCalledInForecast { get; set; }
}