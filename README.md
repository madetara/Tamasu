# Tamasu

[![Build Status](https://travis-ci.com/madetara/Tamasu.svg?token=AfCFWAfau8Sg4CGGMdnp&branch=master)](https://travis-ci.com/madetara/Tamasu)

## Инструкция по работе с репозиторием.

### Первые шаги

1. Нажать на кнопку `Fork` в правом верхнем углу главной страницы -- это создаст копию репозитория в вашем аккаунте.
![](https://disk.skbkontur.ru/index.php/s/tcKePmt5gickeZq/preview)
2. Зайти в вашу версию репозитория и скопировать ссылку отсюда
![](https://disk.skbkontur.ru/index.php/s/rc26DscDKfWmDLL/preview)
3. Выполнить команду `git clone <сюда вставить ссылку>`.
4. Скопировать ссылку из **ОСНОВНОГО** репозитория и выполнить команду `git remote add upstream <ссылка>`
5. Проверить что команда `git remote -v` выводит адреса вашего и основного репозиториев.
6. Создать новую ветку с помощью команды `git checkout -b <имя вашей новой ветки>`
7. Вести разработку в созданной ветке

### Синхронизация работы

Во время работы над проектом важно синхронизировать изменения с главным репозиторием, для этого:
1. Выполнить команду `git fetch upstream`
2. Переключиться на вашу локальную `master` ветку с помощью команды `git checkout master`.
3. Выполнить команду `git merge upstream/master`.
