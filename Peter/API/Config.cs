namespace Meddl
{
    public class Config
    {
        public static string APIVersion = "10";
        public static bool IsBot = false;

        public enum Wait
        {
            Short = 0, Long = 1
        }

        public static void Sleep(Wait option)
        {
            switch(option)
            {
                case Wait.Short:
                    Thread.Sleep(200);
                    break;
                case Wait.Long:
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}
