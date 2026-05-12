using WMPLib;

public static class MusicManager
{
    private static WindowsMediaPlayer player = new WindowsMediaPlayer();
    private static bool sonando = false;

    public static void Play(string ruta)
    {
        if (sonando) return;

        player.URL = ruta;
        player.settings.setMode("loop", true);
        player.settings.volume = 100;
        player.controls.play();

        sonando = true;
    }
}