using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance {get; private set;}
    
    [SerializeField] private Sprite playMusicSprite;
    [SerializeField] private Sprite muteMusicSprite;
    //[SerializeField] private Image startSceneMusicImage;
//    [SerializeField] private Image musicBtnImage;
    [SerializeField] private int maxNumberOfSounds;
    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource audioSourceSounds;
    [SerializeField]
    private AudioSource audioSourceMusic;
    [SerializeField]
    private AudioSource audioSourceNatureMusic;

    [Header("Sounds Info")]
    [SerializeField] private SoundInfo soundInfo;

    private static bool isSoundsMuted = false;

    public bool IsSoundsMuted
    {
        get => isSoundsMuted;
        set => isSoundsMuted = value;
    }

    private static bool isMusicMuted;
    //public bool IsMusicsMuted { get { return isMusicMuted; } }

    private bool isMainMusicPlaying;
    private bool isStartMusicPlaying;
    //private static bool instance = false;
    private int numbOfPlayingSounds;


    [System.Serializable]
    public class SoundInfo
    {
        [Header("Music Audio Clips")]
        public AudioClip mainMusicClip;
        public float mainMusicVolume;
        public AudioClip natureMusicClip;
        public float natureMusicVolume;
        public AudioClip titleMusicClip;
        public float titleMusicVolume;

        [Header("Game Play Clips")]
        public AudioClip buildTowerClip;
        public float buildTowerVolume;
        public AudioClip upgradeTowerClip;
        public float upgradeTowerVolume;
        public AudioClip[] sheepSoundClips;
        public float sheepSoundVolume;
        public AudioClip sheepDiedClip;
        public float sheepDiedVolume;
        public AudioClip destroyTowerClip;
        public float destroyTowerVolume;
        public AudioClip wolfSoundClip;
        public float wolfSoundVolume;
        public AudioClip wolfDiedClip;
        public float wolfDiedVolume;
        public AudioClip throwWeaponClip;
        public float throwWeaponVolume;
        public AudioClip hitWeaponClip;
        public float hitWeaponVolume;
        public AudioClip hunterDiedClip;
        public float hunterDiedVolume;
        public AudioClip wolfHurtClip;
        public float wolfHurtVolume;
        public AudioClip wolfAttackClip;
        public float wolfAttackVolume;

        //public AudioClip spearClip;
        //public float spearVolume;
        //public AudioClip spellClip;
        //public float spellVolume;
        //public AudioClip chainClip;
        //public float chainVolume;
        //public AudioClip kingClip;
        //public float kingVolume;
        //public AudioClip coinClip;
        //public float coinVolume;
        //public AudioClip loseClip;
        //public float loseVolume;
        //public AudioClip bowReleaseClip;
        //public float bowReleaseVolume;
        //public AudioClip arrowShootClip;
        //public float arrowShootVolume;
        //public AudioClip[] arrowHitClips;
        //public float arrowHitVolume;
        //public AudioClip[] workerAxeClips;
        //public float workerAxeVolume;
    }

    void Awake()
    {
        Instance = this;
        isMusicMuted = false;
        isSoundsMuted = false;
        numbOfPlayingSounds = 0;
        PlayTitleMusic();
        
        //PlayNatureMusic();
    }

    private void Start()
    {
        StartCoroutine(PlayIdelSheepSound());
        StartCoroutine(PlayIdelWolfSound());
        
    }



    public void PlayTitleMusic()
    {
        isMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.titleMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void PlayMainMusic()
    {
        isMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.mainMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();

        isMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceNatureMusic.clip = soundInfo.natureMusicClip;
        audioSourceNatureMusic.loop = true;
        audioSourceNatureMusic.Play();

//        musicBtnImage.sprite = muteMusicSprite;
    }

    //public void UnMuteMainMusic()
    //{
    //    if (!isMusicMuted)
    //    {
    //        isMusicMuted = false;
    //        IsSoundsMuted = false;
    //        audioSourceMusic.clip = soundInfo.mainMusicClip;
    //        isMainMusicPlaying = true;
    //        isStartMusicPlaying = false;
    //        //startSceneMusicImage.sprite = playMusicSprite;
    //        //battelSceneMusicImage.sprite = playMusicSprite;
    //        if (audioSourceMusic.isPlaying)
    //        {
    //            audioSourceMusic.UnPause();
    //        }
    //        else
    //        {
    //            audioSourceMusic.Play();
    //        }
    //    }
    //}

    //public void PlayNatureMusic()
    //{
    //    isMusicMuted = false;
    //    IsSoundsMuted = false;
    //    audioSourceNatureMusic.clip = soundInfo.natureMusicClip;
    //    audioSourceNatureMusic.loop = true;
    //    audioSourceNatureMusic.Play();

    //    //startSceneMusicImage.sprite = playMusicSprite;
        
    //    musicBtnImage.sprite = muteMusicSprite;
    //}

    //public void UnMuteStartMusic()
    //{
    //    if (!isMusicMuted)
    //    {
    //        isMusicMuted = false;
    //        IsSoundsMuted = false;
    //        audioSourceMusic.clip = soundInfo.natureMusicClip;
    //        isMainMusicPlaying = false;
    //        isStartMusicPlaying = true;
    //        //startSceneMusicImage.sprite = playMusicSprite;
    //        //battelSceneMusicImage.sprite = playMusicSprite;

    //        if (audioSourceMusic.isPlaying)
    //        {
    //            audioSourceMusic.UnPause();
    //        }
    //        else
    //        {
    //            audioSourceMusic.Play();
    //        }
    //        //SaveFiles.SetStringPlayerPref("IsMusicMuted", isMusicMuted.ToString());//save the current music state
    //    }
    //}


    //public void MuteStartMusic()
    //{
    //    isMusicMuted = true;
    //    IsSoundsMuted = true;
    //    audioSourceMusic.Pause();

    //    musicBtnImage.sprite = playMusicSprite;
    //    //SaveFiles.SetStringPlayerPref("IsMusicMuted", isMusicMuted.ToString());//save the current music state
    //}

    public void MuteMainMusic()
    {
        isMusicMuted = true;
        IsSoundsMuted = true;
        audioSourceMusic.Pause();

        isMusicMuted = true;
        IsSoundsMuted = true;
        audioSourceNatureMusic.Pause();

//        musicBtnImage.sprite = playMusicSprite;
        //SaveFiles.SetStringPlayerPref("IsMusicMuted", isMusicMuted.ToString());//save the current music state
    }

    //public void StopStartMusic()
    //{
    //    isMusicMuted = true;
    //    IsSoundsMuted = true;
    //    audioSourceMusic.Stop();
    //    isStartMusicPlaying = true;
    //    //SaveFiles.SetStringPlayerPref("IsMusicMuted", isMusicMuted.ToString());//save the current music state
    //}


/// <param name="hasToMute">set to false if you want to stop the main music withour muting the all sounds</param>
    //public void StopMainMusic(bool hasToMute = true)
    //{
    //    if (hasToMute)
    //    {
    //        isMusicMuted = true;
    //        IsSoundsMuted = true;
    //    }
        
    //    audioSourceMusic.Stop();
    //    isMainMusicPlaying = false;
    //    //startSceneMusicImage.sprite = muteMusicSprite;
    //    //battelSceneMusicImage.sprite = muteMusicSprite;
    //    //SaveFiles.SetStringPlayerPref("IsMusicMuted", isMusicMuted.ToString());//save the current music state
    //}

    public void UpdateMusicState()
    {
        print(isMainMusicPlaying);
        if (isMusicMuted)
        {
            PlayMainMusic();

            //PlayNatureMusic();
        }
        else
        {
            //MuteStartMusic();
            MuteMainMusic();
        }
    }


    public void PlaySheepSoundAudio()
    {
        if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
        {
            numbOfPlayingSounds++;
            int rand = Random.Range(0, soundInfo.sheepSoundClips.Length);
            if (rand == 1)
            {
                audioSourceSounds.PlayOneShot(soundInfo.sheepSoundClips[rand], soundInfo.sheepSoundVolume);
            }
            else
            {
                audioSourceSounds.PlayOneShot(soundInfo.sheepSoundClips[rand], soundInfo.sheepSoundVolume);
            }
        }
    }

    public void PlaySheepDiedAudio()
    {
        if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.sheepDiedClip, soundInfo.sheepDiedVolume);
        }
    }

    public void PlayWolfSoundAudio()
    {
        if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.wolfSoundClip, soundInfo.wolfSoundVolume);
        }
    }

    public void PlayWolfDiedAudio()
    {
        if (!IsSoundsMuted)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.wolfDiedClip, soundInfo.wolfDiedVolume);
        }
    }

    public void PlayWolfHurtAudio()
    {
        if (!IsSoundsMuted)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.wolfHurtClip, soundInfo.wolfHurtVolume);
        }
    }

    public void PlayWolfAttackAudio()
    {
        if (!IsSoundsMuted)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.wolfAttackClip, soundInfo.wolfAttackVolume);
        }
    }

    public void PlayThrowWeaponAudio()
    {
        if (!IsSoundsMuted)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.throwWeaponClip, soundInfo.throwWeaponVolume);
        }
    }

    public void PlayHitWeaponAudio()
    {
        if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.hitWeaponClip, soundInfo.hitWeaponVolume);
        }
    }

    public void PlayBuildTowerAudio()
    {
        if (!IsSoundsMuted)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.buildTowerClip, soundInfo.buildTowerVolume);
        }
    }

    public void PlayDestroyTowerAudio()
    {
        if (!IsSoundsMuted)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.destroyTowerClip, soundInfo.destroyTowerVolume);
        }
    }

    public void PlayUpgradeTowerAudio()
    {
        if (!IsSoundsMuted)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.upgradeTowerClip, soundInfo.upgradeTowerVolume);
        }
    }

    public void PlayHunterDiedAudio()
    {
        if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
        {
            numbOfPlayingSounds++;
            audioSourceSounds.PlayOneShot(soundInfo.hunterDiedClip, soundInfo.hunterDiedVolume);
        }
    }

    public IEnumerator PlayIdelSheepSound()
    {
        while (true)
        {
            PlaySheepSoundAudio();
            yield return new WaitForSeconds(10);
        }
    }

    public IEnumerator PlayIdelWolfSound()
    {
        while (true)
        {
            PlayWolfSoundAudio();
            yield return new WaitForSeconds(13);
        }
    }

    //public void PlayBladHtAudio()
    //{
    //    if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
    //    {
    //        numbOfPlayingSounds++;
    //        int rand = Random.Range(0, soundInfo.bladHitClips.Length);
    //        if (rand == 1)
    //        {
    //            audioSourceSounds.PlayOneShot(soundInfo.bladHitClips[rand], .1f);
    //        }
    //        else
    //        {
    //            audioSourceSounds.PlayOneShot(soundInfo.bladHitClips[rand], soundInfo.bladHitVolume);
    //        }
    //    }
    //}




    //public void PlayShieldHitAudio()
    //{
    //    if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
    //    {
    //        numbOfPlayingSounds++;
    //        audioSourceSounds.PlayOneShot(soundInfo.shieldHitClip, soundInfo.shieldHitVolume);
    //    }
    //}

    //public void PlaySpearAudio()
    //{
    //    if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
    //    {
    //        numbOfPlayingSounds++;
    //        audioSourceSounds.PlayOneShot(soundInfo.spearClip, soundInfo.spearVolume);
    //    }
    //}

    //public void PlaySpellAudio()
    //{
    //    if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
    //    {
    //        numbOfPlayingSounds++;
    //        audioSourceSounds.PlayOneShot(soundInfo.spellClip, soundInfo.spellVolume);
    //    }
    //}

    //public void PlayChianAudio()
    //{
    //    if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
    //    {
    //        numbOfPlayingSounds++;
    //        audioSourceSounds.PlayOneShot(soundInfo.chainClip, soundInfo.chainVolume);
    //    }
    //}

    //public void PlayWorkerAxeAudio()
    //{
    //    if (!IsSoundsMuted && numbOfPlayingSounds < maxNumberOfSounds)
    //    {
    //        numbOfPlayingSounds++;
    //        audioSourceSounds.PlayOneShot(soundInfo.workerAxeClips[Random.Range(0, soundInfo.bladHitClips.Length)], soundInfo.workerAxeVolume);
    //    }
    //}
}
