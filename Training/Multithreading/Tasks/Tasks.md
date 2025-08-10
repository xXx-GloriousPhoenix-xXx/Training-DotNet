# Tasks
> Расскажи что мне стоит знать в многопоточности и что нужно изучить (C#)
<p>Многопоточность в C# — это обширная тема, которая критически важна для создания эффективных приложений. Вот структурированный путь изучения:
Основы, которые нужно понимать</p>
## Базовые концепции:
<ul>
    <li>Что такое поток (Thread) и чем он отличается от процесса</li>
    <li>Разница между параллелизмом и конкурентностью</li>
    <li>Понятие Thread Pool и зачем он нужен</li>
    <li>Контекст синхронизации (SynchronizationContext)</li>
</ul>
## Проблемы многопоточности:
<ul>
    <li>Race conditions (состояние гонки)</li>
    <li>Deadlocks (взаимоблокировки)</li>
    <li>Starvation (голодание потоков)</li>
    <li>Context switching и его стоимость</li>
</ul>
## Что изучать поэтапно
<dl>
    <dt>Базовый уровень:</dt>
    <dd>Класс Thread — создание и управление потоками</dd>
    <dd>ThreadStart и ParameterizedThreadStart делегаты</dd>
    <dd>Методы Join(), Sleep(), Abort() (deprecated)</dd>
    <dd>Свойства потоков: IsAlive, Priority, IsBackground</dd>  
</dl>


    

2. Синхронизация потоков:

    lock statement (самое важное для начала)
    Monitor класс — более гибкая альтернатива lock
    Mutex, Semaphore, AutoResetEvent, ManualResetEvent
    ReaderWriterLockSlim для сценариев чтения/записи
    Interlocked класс для атомарных операций

3. Современный подход (это приоритет):

    async/await — асинхронное программирование
    Task и Task<T> классы
    Task.Run(), Task.Factory.StartNew()
    ConfigureAwait(false) и почему это важно
    Обработка исключений в асинхронном коде

4. Параллельное программирование:

    Parallel класс: ForEach(), For(), Invoke()
    PLINQ (Parallel LINQ)
    CancellationToken для отмены операций
    Progress<T> для отчетности о прогрессе

5. Коллекции для многопоточности:

    ConcurrentQueue<T>, ConcurrentStack<T>
    ConcurrentDictionary<TKey, TValue>
    BlockingCollection<T>
    Channel<T> (более современная альтернатива)

6. Продвинутые темы:

    TaskScheduler — управление выполнением задач
    AsyncLocal<T> — локальные данные для асинхронного контекста
    SemaphoreSlim — асинхронная версия семафора
    ConfigureAwait и работа с UI потоками

Практические рекомендации

Начни с async/await, а не с Thread класса. Это современный стандарт в C# и покрывает 90% сценариев использования.

Золотые правила:

    Избегай Thread.Sleep() — используй await Task.Delay()
    Не блокируй UI поток долгими операциями
    Всегда используй ConfigureAwait(false) в библиотечном коде
    Предпочитай Task.Run() вместо создания новых потоков
    Используй CancellationToken для отмены длительных операций

Частые ошибки новичков:

    Блокировка асинхронного кода через .Result или .Wait()
    Забывание про ConfigureAwait(false)
    Использование async void (только для event handlers)
    Неправильное управление исключениями в async методах

Порядок изучения:

    Сначала изучи async/await и Task
    Потом базовую синхронизацию (lock, SemaphoreSlim)
    Затем Parallel класс и PLINQ
    В последнюю очередь — низкоуровневые примитивы

Многопоточность требует много практики, поэтому обязательно пиши небольшие примеры и эксперименты для каждой изученной концепции.
Это поможет глубже понять, как всё работает на практике.
