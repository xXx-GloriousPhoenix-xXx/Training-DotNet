# Tasks

> Расскажи что мне стоит знать в многопоточности и что нужно изучить (C#)

Многопоточность в C# — это обширная тема, которая критически важна для создания эффективных приложений. Вот структурированный путь изучения:

## Основы, которые нужно понимать

### Базовые концепции:

* Что такое поток (Thread) и чем он отличается от процесса
* Разница между параллелизмом и конкурентностью
* Понятие Thread Pool и зачем он нужен
* Контекст синхронизации (SynchronizationContext)

### Проблемы многопоточности:

* Race conditions (состояние гонки)
* Deadlocks (взаимоблокировки)
* Starvation (голодание потоков)
* Context switching и его стоимость

## Что изучать поэтапно

<dl>    <dt>1. Базовый уровень:</dt>    <dd>Класс <code>Thread</code> — создание и управление потоками</dd>    <dd><code>ThreadStart</code> и <code>ParameterizedThreadStart</code> делегаты</dd>    <dd>Методы <code>Join()</code>, <code>Sleep()</code>, <code>Abort()</code> (deprecated)</dd>    <dd>Свойства потоков: <code>IsAlive</code>, <code>Priority</code>, <code>IsBackground</code></dd> </dl> <dl>    <dt>2. Синхронизация потоков:</dt>    <dd><code>lock</code> statement (самое важное для начала)</dd>    <dd><code>Monitor</code> класс — более гибкая альтернатива lock</dd>    <dd><code>Mutex</code>, <code>Semaphore</code>, <code>AutoResetEvent</code>, <code>ManualResetEvent</code></dd>    <dd><code>ReaderWriterLockSlim</code> для сценариев чтения/записи</dd>    <dd><code>Interlocked</code> класс для атомарных операций</dd> </dl> <dl>    <dt>3. Современный подход (это приоритет):</dt>    <dd><code>async/await</code> — асинхронное программирование</dd>    <dd><code>Task</code> и <code>Task<T></code> классы</dd>    <dd><code>Task.Run()</code>, <code>Task.Factory.StartNew()</code></dd>    <dd><code>ConfigureAwait(false)</code> и почему это важно</dd>    <dd>Обработка исключений в асинхронном коде</dd> </dl> <dl>    <dt>4. Параллельное программирование:</dt>    <dd><code>Parallel</code> класс: <code>ForEach()</code>, <code>For()</code>, <code>Invoke()</code></dd>    <dd>PLINQ (Parallel LINQ)</dd>    <dd><code>CancellationToken</code> для отмены операций</dd>    <dd><code>Progress<T></code> для отчетности о прогрессе</dd> </dl> <dl>    <dt>5. Коллекции для многопоточности:</dt>    <dd><code>ConcurrentQueue<T></code>, <code>ConcurrentStack<T></code></dd>    <dd><code>ConcurrentDictionary<TKey, TValue></code></dd>    <dd><code>BlockingCollection<T></code></dd>    <dd><code>Channel<T></code> (более современная альтернатива)</dd> </dl> <dl>    <dt>6. Продвинутые темы:</dt>    <dd><code>TaskScheduler</code> — управление выполнением задач</dd>    <dd><code>AsyncLocal<T></code> — локальные данные для асинхронного контекста</dd>    <dd><code>SemaphoreSlim</code> — асинхронная версия семафора</dd>    <dd><code>ConfigureAwait</code> и работа с UI потоками</dd> </dl> ## Практические рекомендации

Начни с <code>async/await</code>, а не с Thread класса. Это современный стандарт в C# и покрывает 90% сценариев использования.

### Золотые правила:

* Избегай <code>Thread.Sleep()</code> — используй <code>await Task.Delay()</code>
* Не блокируй UI поток долгими операциями
* Всегда используй <code>ConfigureAwait(false)</code> в библиотечном коде
* Предпочитай <code>Task.Run()</code> вместо создания новых потоков
* Используй <code>CancellationToken</code> для отмены длительных операций

### Частые ошибки новичков:

* Блокировка асинхронного кода через <code>.Result</code> или <code>.Wait()</code>
* Забывание про <code>ConfigureAwait(false)</code>
* Использование <code>async void</code> (только для event handlers)
* Неправильное управление исключениями в async методах

### Порядок изучения:

* Сначала изучи <code>async/await</code> и <code>Task</code>
* Потом базовую синхронизацию (<code>lock</code>, <code>SemaphoreSlim</code>)
* Затем <code>Parallel</code> класс и PLINQ
* В последнюю очередь — низкоуровневые примитивы

Многопоточность требует много практики, поэтому обязательно пиши небольшие примеры и эксперименты для каждой изученной концепции. Это поможет глубже понять, как всё работает на практике.
