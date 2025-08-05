using System;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos.Streams;

namespace Module18._4
{
    class Receiver 
    {
        public static async Task OperationVideo()
        {
            try
            {
                //Получаем ссылку на видео
                Console.Write("Введите ссылку на видео для скачивания: ");
                var videoUrl = Console.ReadLine();
                var youtubeClient = new YoutubeClient();
                var video = await youtubeClient.Videos.GetAsync(videoUrl);
                Console.WriteLine($"Название: {video.Title}");
                Console.WriteLine($"Описание: {video.Description}");

                //Очистите заголовок видео, чтобы удалить недопустимые символы из имени файла
                string sanitizedTitle = string.Join("_", video.Title.Split(Path.GetInvalidFileNameChars()));

                //Путь для сохранения файла
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string outputFilePath = Path.Combine(projectPath, sanitizedTitle);

                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                await youtubeClient.Videos.DownloadAsync(videoUrl, $"{outputFilePath}.{streamInfo.Container}", static builder =>
                {
                    builder.SetPreset(ConversionPreset.UltraFast);
                });

                Console.Write("Видео загружено");
            }
            catch (Exception ex) when (ex is HttpRequestException)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
