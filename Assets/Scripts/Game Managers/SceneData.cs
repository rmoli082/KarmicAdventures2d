using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneData : MonoBehaviour
{
    public GameObject player;
    public GameObject playerInfo;
    public Animator playerAnimator;
    public AudioSource playerAudioSource;
    public Transform respawnPosition;
    public Text level;
    public GameObject inventoryCanvas;
    public GameObject inventorySlots;
    public GameObject avatarPanel;
    public TextMeshProUGUI goldPieces;
    public AvatarSlotController currentAvatar;

    public GameObject questCompletedBox;
    public GameObject questPanel;
    public GameObject questContentFrame;
    public GameObject questDetailsPane;

    public TextMeshProUGUI questDetailsStory;
    public TextMeshProUGUI questDetailsTitle;
    public TextMeshProUGUI questDetailsDesc;
    public TextMeshProUGUI questRewards;

    public GameObject pause;
    public GameObject controlsFrame;
    public GameObject warpPopup;
    public GameObject tooltip;

    public GameObject levelUpPanel;
    public TextMeshProUGUI levelUpText;
    public GameObject statsPanel;
    public GameObject levelUpButton;

    public GameObject overviewMap;

    public GameObject karmaAwardedDisplay;
}
