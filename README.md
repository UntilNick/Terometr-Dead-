# TeraPluginsManager

Изначально проект задумывался как простой ДПС метер с несколькими настройками, однако в процессе написания понадобился сниффер, а теперь я разрабатываю полноценный движок аддонов для игры тера.

Для поддержания такого проекта мне нужна будет помощь, пишите [**сюда**](https://github.com/Detrav/Terometr/issues).

Позже будут разработаны пара плагинов: Дпс метер, простой с несколькими настройкам, и нормальное окно рейда.

## Установка

1.  Для работы программы требуется дополнительное ПО:
  * [WinpkFilter 3.2.3](http://www.ntkernel.com/downloads/winpkflt_rtl.zip)
  * [Microsoft .NET Framework 4.5.1](https://www.microsoft.com/ru-RU/download/details.aspx?id=40773)
2.  Устанавливаем ПО.
3.  Распаковываем архив с моей программой.
4.  Запускаем мою программу.
5.  Запускаем игру ТЕРА.

## Вопросы и ответы

  [**Задать свой вопрос можно здесь!**](https://github.com/Detrav/Terometr/issues)

## От автора

Сразу хочу сказать, что всем ПО вы пользуетесь на свой страх и риск. Если вас забанят, украдут личные данные, удалят персонажа, будут спамить голд в общий чат и т.п. — это не мои проблемы. Администрация написала, что пока программа будет только считывать данные, то бана не будет.

Я знаю 2 хороших варианта перехвата пакетов и оба они могут редактировать сетевой трафик: первый, клиент подключается к программе а программа к серверу, в итоге весь поток данных будет происходить через ПО, второй, драйвер пересылает программе пакеты сети, основываясь на фильтре, и ждёт в результате пакет назад.

В данной программе используется второй вариант, а это значит, что весь поток данных обрабатывается в программе и посылается назад, не факт, что программа ничего не сделала с потоком, она могла спокойно заменить пакет другой, а это вмешательство в игровой процесс.
