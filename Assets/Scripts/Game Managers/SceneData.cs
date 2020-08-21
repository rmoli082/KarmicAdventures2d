using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneData : MonoBehaviour
{
    public GameObject player;
    public GameObject inventoryCanvas;
    public GameObject playerInfo;
    public GameObject goldHeader;
    public Text goldPieces;
    public GameObject avatarHeader;
    public AvatarSlotController currentAvatar;
    public GameObject avatarPanel;
    public Text level;
    public GameObject pause;

    public GameObject questCompletedBox;
    public GameObject questPanel;
    public GameObject questContentFrame;
    public GameObject questDetailsPane;

    public TextMeshProUGUI questDetailsStory;
    public TextMeshProUGUI questDetailsTitle;
    public TextMeshProUGUI questDetailsDesc;
    public TextMeshProUGUI questRewards;

    public GameObject controlsFrame;
    public GameObject warpPopup;
    public GameObject tooltip;

    public Transform respawnPosition;

    public Animator playerAnimator;
    public AudioSource playerAudioSource;

    public GameObject levelUpPanel;
    public TextMeshProUGUI levelUpText;
    public GameObject statsPanel;
    public GameObject levelUpButton;
}
