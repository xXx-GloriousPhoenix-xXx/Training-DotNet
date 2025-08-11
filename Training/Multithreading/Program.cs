class ThreadBasicsExample
{
    static void Main()
    {
        Console.WriteLine($"Главный поток ID: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("=== Пример 1: ThreadStart (без параметров) ===");

        // Создание потока с ThreadStart делегатом
        Thread thread1 = new Thread(new ThreadStart(SimpleWork));

        // Настройка свойств потока
        thread1.Name = "Worker-1";
        thread1.Priority = ThreadPriority.Normal;
        thread1.IsBackground = false; // Foreground поток

        Console.WriteLine($"Поток создан. IsAlive: {thread1.IsAlive}");

        // Запуск потока
        thread1.Start();
        Console.WriteLine($"Поток запущен. IsAlive: {thread1.IsAlive}");

        // Ждём завершения потока
        thread1.Join();
        Console.WriteLine($"Поток завершён. IsAlive: {thread1.IsAlive}");

        Console.WriteLine("\n=== Пример 2: ParameterizedThreadStart (с параметром) ===");

        // Создание потока с параметром
        Thread thread2 = new Thread(new ParameterizedThreadStart(WorkWithParameter));
        thread2.Name = "Worker-2";
        thread2.Priority = ThreadPriority.AboveNormal;
        thread2.IsBackground = true; // Background поток

        // Запуск с параметром
        thread2.Start("Привет из параметра!");
        thread2.Join();

        Console.WriteLine("\n=== Пример 3: Несколько потоков с Join ===");

        Thread[] workers = new Thread[3];

        for (int i = 0; i < workers.Length; i++)
        {
            int taskNumber = i + 1; // Захватываем значение для замыкания
            workers[i] = new Thread(() => LongWork(taskNumber));
            workers[i].Name = $"LongWorker-{taskNumber}";
            workers[i].Start();
        }

        Console.WriteLine("Все потоки запущены, ждём их завершения...");

        // Ждём завершения всех потоков
        foreach (Thread worker in workers)
        {
            worker.Join();
        }

        Console.WriteLine("Все потоки завершены!");

        Console.WriteLine("\n=== Пример 4: Background vs Foreground потоки ===");

        Thread backgroundThread = new Thread(EndlessWork);
        backgroundThread.Name = "Background-Worker";
        backgroundThread.IsBackground = true; // Не будет блокировать завершение программы
        backgroundThread.Start();

        Thread.Sleep(2000); // Даём background потоку поработать 2 секунды
        Console.WriteLine("Главный поток завершается. Background поток будет принудительно остановлен.");

        // Программа завершится, не дожидаясь background потока
    }

    // Простая работа без параметров
    static void SimpleWork()
    {
        Console.WriteLine($"  >> Поток {Thread.CurrentThread.Name} (ID: {Thread.CurrentThread.ManagedThreadId}) начал работу");

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"  >> {Thread.CurrentThread.Name}: выполняю шаг {i}");
            Thread.Sleep(500); // Имитируем работу
        }

        Console.WriteLine($"  >> Поток {Thread.CurrentThread.Name} завершил работу");
    }

    // Работа с параметром
    static void WorkWithParameter(object parameter)
    {
        string message = (string)parameter;
        Console.WriteLine($"  >> Поток {Thread.CurrentThread.Name} получил: {message}");

        Console.WriteLine($"  >> Приоритет: {Thread.CurrentThread.Priority}");
        Console.WriteLine($"  >> Background: {Thread.CurrentThread.IsBackground}");

        Thread.Sleep(1000);
        Console.WriteLine($"  >> Поток {Thread.CurrentThread.Name} закончил обработку параметра");
    }

    // Длительная работа для демонстрации Join
    static void LongWork(int taskNumber)
    {
        Console.WriteLine($"  >> Задача {taskNumber} запущена в потоке {Thread.CurrentThread.Name}");

        Random random = new Random();
        int workTime = random.Next(1000, 3000); // От 1 до 3 секунд

        Thread.Sleep(workTime);
        Console.WriteLine($"  >> Задача {taskNumber} завершена за {workTime}мс");
    }

    // Бесконечная работа для демонстрации Background потоков
    static void EndlessWork()
    {
        int counter = 0;
        while (true)
        {
            Console.WriteLine($"  >> Background поток работает... {++counter}");
            Thread.Sleep(500);

            if (counter >= 10) break; // Защита от реального бесконечного цикла в примере
        }
    }
}