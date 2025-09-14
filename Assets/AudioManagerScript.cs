using UnityEngine;
using UnityEngine.SceneManagement; // Добавляем для работы с событиями загрузки сцен

public class AudioManagerScript : MonoBehaviour
{
    private static AudioManagerScript instance = null; // Статическая ссылка на единственный экземпляр

    void Awake()
    {
        // Проверяем, существует ли уже экземпляр этого менеджера
        if (instance != null && instance != this)
        {
            // Если существует другой экземпляр, уничтожаем текущий
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // Если это первый экземпляр, устанавливаем его как наш "синглтон"
            instance = this;
        }

        // Запрещаем уничтожение этого GameObject при загрузке новой сцены
        DontDestroyOnLoad(this.gameObject);
    }

    // Вы можете добавить методы для управления звуком, например:
    public void PlaySound(AudioClip clip)
    {
        // Допустим, у вас есть несколько AudioSource для разных звуков
        // GetComponent<AudioSource>().PlayOneShot(clip);
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void PlayMusic()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}