using UsingCmd;

namespace Test
{
    class CMD
    {
        public static void Main()
        {
            Console.WriteLine("Введите диреторию для поиска");
            string path = Path(Console.ReadLine());
            string pathDisk = path.Substring(0, 3);

            Console.WriteLine("Введите формат для поиска");
            string format = Format(Console.ReadLine());

            Console.WriteLine("Некоторое ожидание для осознания, зачем в задании был пункт про ассинхронные методы...");

            // Ищем все форматы по заданной директории в cmd
            string inputDir = ProcessCmd.Cmd("where /R " + path + " *" + format);
            // Ищем все форматы по всему диску 
            string inputFullDisk = ProcessCmd.Cmd("where /R " + pathDisk + " *" + format);

            // Удалим одинаковый текст через списки
            List<string> listDir = new List<string>();
            listDir = inputDir.Split(format).ToList();

            List<string> listFullDisk = new List<string>();
            listFullDisk = inputFullDisk.Split(format).ToList();

            List<string> result = listFullDisk.Except(listDir).Select(x => x.Replace(@"\r\nD:", "D:")).ToList();

        }

        // Проверка на корректность введенного пути
        public static string Path(string path)
        {
            try
            {
                string pathDisk = path.Substring(0, 3);
                char one = ':'; char two = '\\';
                if ((Char.IsLetter(path[0]) == true) &&
                    one == path[1] &&
                    two == path[2])
                    return path;
                else
                    Console.WriteLine("Ошибка - В указанной директории синтаксическая ошибка");
                    return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка - Введенный путь содержить меньше 3-ех символов");
                return null;
            }

        }
        // Проверка на корректность введенного формата
        public static string Format(string format)
        {
            char note = '.';
            if (format[0] == note)
                return format;
            else
                Console.WriteLine("Ошибка - формат должен начинаться с '.' ");
            return null;
        }
    }
}

